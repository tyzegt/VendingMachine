import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";
import AuthRequest from "@/template/models/AuthRequest";
import Product from "@/template/models/Product";
import Coin from "@/template/models/Coin";
import Category from "@/template/models/Category";
import RefData from "@/template/util/RefData";


@Component({
    components: {
        
    }
})
export default class AdminPanel extends Vue {
    
    login: string = "";
    password: string = "";
    isSigned: boolean = false;
    coins: Coin[] = [];
    products: Product[] = [];
    categories: Category[] = [];
    loading = true;

    pageNumber = 0;
    perPage = 10;

    mounted() {
        console.log("AdminPanel mounted");
        this.checkSession();
    }

    checkSession() {
        axios.get("/Admin/IsLoggedIn").then(result => {
            this.isSigned = result.data;
            this.loading = false;
        }).catch(error => {
            this.loading = false;
        });
    }

    signIn() {
        var request = new AuthRequest();
        request.login = this.login;
        request.password = this.password;
        axios.post("/Admin/Login", request).then(result => {
            if(result.status == 200) {
                this.isSigned = true;
                this.loadRefData();
                this.loadProducts();
            }
        }).catch(error => {
            this.$bvToast.toast("Неверный логин или пароль", {
                title: "Ошибка",
                variant: "danger",
                autoHideDelay: 5000,
                appendToast: true,
                toaster: "b-toaster-top-full",
            });
            this.password = "";
        }); 
    }

    async loadRefData() {
        this.coins = await RefData.getCoins();
        this.categories = await RefData.getCategories();
    }

    async loadProducts() {
        console.log(await RefData.getProductsAll());
    }
}