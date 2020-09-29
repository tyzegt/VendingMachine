import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";
import Coin from "@/template/models/Coin";
import Product from "@/template/models/Product";
import store from "@/template/store/store";
import RefData from "@/template/util/RefData";


@Component({
    components: {
        MessageDisplay: require("@/template/components/MessageDisplay/MessageDisplay.vue").default,
        Showcase: require("@/template/components/Showcase/Showcase.vue").default,
    }
})
export default class VendingMachine extends Vue {
    
    message: string = "Добро пожаловать!";
    coins: Coin[] = [];
    loadingCoin = false;
    loadingSum = true;
    
    mounted() {
        console.log("VendingMachine mounted");
        this.refresh();
    }

    refresh() {
        this.getSum();
        this.getCoins();
    }

    purchase(product: Product) {
        this.message = "Вы купили товар '" + product.name + "' за " + product.price + "р. ";
        var change = this.$store.state.totalSum - product.price;
        if(change > 0) this.message += "Ваша сдача: " + change + "р.";
        this.refresh();
    }

    returnChange() {
        axios.post("/Coins/ReturnChange").then(result => {
            this.message = "Ваша сдача: ";
            var coins = result.data as Coin[];

            for(var i = 0; i < coins.length; i++) {
                if (coins[i].count > 0) {
                    this.message += coins[i].count + " " + this.getPlural(coins[i].count) + " по " + coins[i].value + "р.";
                    if (i != coins.length - 1) this.message += ", ";
                }
            }

            this.$store.state.totalSum = 0;
        })
        .catch(error => {
            console.log(error.response);
        });
    }

    getPlural(count: number) {
        switch (count) {
            case 1:
                return "монета";
            case 2:
            case 3:
            case 4:
                return "монеты";
            default:
                return "монет";
        }
    }

    getSum() {
        axios.get("/Coins/GetSum").then(result => {
            this.$store.state.totalSum = result.data; 
            this.loadingSum = false;
        })
        .catch(error => {
            console.log(error.response);
        });
    }

    getCoins() {
        RefData.getCoins().then(result => {
            this.coins = result;
        });
    }

    addCoin(coin: Coin) {
        this.loadingCoin = true;
        if(coin.isAvailable) { 
            axios.post("/Coins/DepositCoin?coinId=" + coin.id).then(result => {
                this.$store.state.totalSum = result.data;
                this.loadingCoin = false;
                this.message = "Внесена монета номиналом " + coin.value + "р.";
                this.getCoins();
            })
            .catch(error => {
                console.log(error.response);
                this.loadingCoin = false;
                this.message = "Не удалось внести монету";
            });            
        }
    }

    getTotalSum() {
        return this.$store.state.totalSum;
    }

    getCoinVariant(isAvailable: boolean) {
        if (isAvailable) return "primary";
        else return "secondary";
    }
}