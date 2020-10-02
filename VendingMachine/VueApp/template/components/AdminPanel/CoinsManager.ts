import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import RefData from "@/template/util/RefData";
import Coin from "@/template/models/Coin";
import { BIconPencil, BIconX, BIconPlus } from 'bootstrap-vue';
import axios from "axios";

@Component({
    components: {
        BIconPencil, BIconX, BIconPlus
    }
})
export default class CoinsManager extends Vue {
    
    coins: Coin[] = [];
    editedCoin: Coin = new Coin();

    columns = [
        {
            label: 'Номинал',
            field: 'value',
        },
        {
            label: 'Количество',
            field: 'count',
        },
        {
            label: 'Активность',
            field: 'isAvailable',
        },
        {
            label: '',
            field: 'edit',
            width: '10%',            
        },

    ];
    
    mounted() {
        this.loadCoins();
    }

    async loadCoins() {
        this.coins = await RefData.getCoins();
        this.resetEditedCoin();
    }
    
    editCoin(id: number) {
        var selectedCoin = this.coins.find(x => x.id == id) as Coin;
        this.editedCoin.id = selectedCoin.id;
        this.editedCoin.count = selectedCoin.count;
        this.editedCoin.value = selectedCoin.value;
        this.editedCoin.isAvailable = selectedCoin.isAvailable;
    }

    addCoin() {
        this.resetEditedCoin();
    }

    resetEditedCoin() {
        this.editedCoin.id = -1;
        this.editedCoin.count = 0;
        this.editedCoin.value = 0;
        this.editedCoin.isAvailable = false;
    }

    saveCoin() {
        var route = this.editedCoin.id == -1 ? "/Coins/AddCoin" : "/Coins/EditCoin";
        axios.post(route, this.editedCoin).then(result => {
            this.toast("Изменения сохранены", "Успешно", "success");
            this.loadCoins();
        }).catch(error => {
            console.log(error);
            this.toast("Что-то пошло не так", "Ошибка", "danger");
            this.loadCoins();
        });
    }

    deleteCoin(id: number) {
        var selectedCoin = this.coins.find(x => x.id == id) as Coin;
        this.$bvModal.msgBoxConfirm("Вы уверены, что хотите безвозвратно удалить выбранную монету?")
        .then(result => {
            if(result) {
                axios.post("/Coins/DeleteCoin", selectedCoin).then(result => {
                    this.toast("Монета удалена", "Успешно", "success");
                    this.loadCoins();
                }).catch(error => {
                    console.log(error);
                    this.toast("Что-то пошло не так", "Ошибка", "danger");
                    this.loadCoins();
                });
            }
        });
    }

    toast(message: string, title: string, variant: string) {
        this.$bvToast.toast(message, {
          title: title,
          variant: variant,
          toaster: 'b-toaster-bottom-right',
          solid: true,
          appendToast: false
        })
    }

}