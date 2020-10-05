import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import RefData from "@/template/util/RefData";
import Product from "@/template/models/Product";
import Category from "@/template/models/Category";
import ProductsRequest from "@/template/models/ProductsRequest";
import { BIconPencil, BIconX, BIconPlus } from 'bootstrap-vue';
import axios from "axios";
import Toaster from "@/template/util/Toaster";


@Component({
    components: {
        BIconPencil, BIconX, BIconPlus
    }
})
export default class ProductsManager extends Vue {
    
    categories: Category[] = [];
    products: Product[] = [];
    
    pageNumber: number = 0;
    perPage: number = 5;
    categoryId: number = 0;
    totalCount: number = 0;

    editedProduct: Product = new Product();

    async mounted() {    
        this.categories = await RefData.getAllCategories();
        await this.loadProducts(0);
    }

    async resetCategory() {
        this.categoryId = 0;
        await this.loadProducts(0);
    }
    
    async pageChanged(arg: any) {
        await this.loadProducts(arg - 1);
    }

    async categoryChanged(arg: any) {
        this.categoryId = arg;
        await this.loadProducts(0);
    }

    async loadProducts(page: number) {        
        var request = new ProductsRequest();     
        request.categoryId = this.categoryId;
        request.itemsPerPage = this.perPage;
        request.pageNumber = page;
        var response = await RefData.getProducts(request); 
        this.products = response.products;
        this.totalCount = response.totalCount;
    }

    onCheck(checked: any, id: any) {
        var product = this.products.find(x => x.id == id) as Product;
        product.isAvailable = checked;
        console.log(checked);        
        console.log(product.isAvailable);
    }

    editProduct(id: number) {
        this.editedProduct = this.products.find(x => x.id == id) as Product;
    }

    deleteProduct(id: number) {
        this.editedProduct = this.products.find(x => x.id == id) as Product;
        this.$bvModal.msgBoxConfirm("Вы уверены, что хотите безвозвратно удалить товар '" + this.editedProduct.name + "'?")
        .then(result => {
            if(result) {
                axios.post("/Product/DeleteProduct", this.editedProduct).then(result => {
                    Toaster.toast(this.$bvToast, "Товар " + this.editedProduct.name + " удалён", "Успешно", "success");
                    this.loadProducts(0);
                }).catch(error => {
                    console.log(error);
                    Toaster.toast(this.$bvToast, "Что-то пошло не так", "Ошибка", "danger");
                });
            }
        });
    }

    cancel() {
        this.loadProducts(this.pageNumber - 1);
    }

    saveProduct() {
        var route = this.editedProduct.id == 0 ? "/Product/AddProduct" : "/Product/EditProduct";
        axios.post(route, this.editedProduct).then(result => {
            Toaster.toast(this.$bvToast, "Изменения сохранены", "Успешно", "success");
            this.loadProducts(0);
        }).catch(error => {
            console.log(error);
            Toaster.toast(this.$bvToast, "Что-то пошло не так", "Ошибка", "danger");
        });
    }

    resetProduct() {
        this.editedProduct = new Product();
    }

    getCategory(id: number) {
        var category = this.categories.find(x => x.id == id) as Category;
        return category.name;
    }
}