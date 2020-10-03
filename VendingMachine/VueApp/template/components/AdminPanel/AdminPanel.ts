import Vue from "vue";
import { Component } from "vue-property-decorator";
import axios from "axios";
import AuthRequest from "@/template/models/AuthRequest";
import "vue-good-table/dist/vue-good-table.css";



@Component({
    components: {
        ProductsManager:  require("@/template/components/AdminPanel/ProductsManager.vue").default,
        CoinsManager:  require("@/template/components/AdminPanel/CoinsManager.vue").default,
        CategoriesManager:  require("@/template/components/AdminPanel/CategoriesManager.vue").default,
    }
})
export default class AdminPanel extends Vue {
    
    login: string = "";
    password: string = "";
    isSigned: boolean = false;
    loading = true;

    async mounted() {
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
}