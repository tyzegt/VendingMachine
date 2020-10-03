import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import RefData from "@/template/util/RefData";
import Product from "@/template/models/Product";
import Category from "@/template/models/Category";


@Component({
    components: {
    }
})
export default class ProductsManager extends Vue {
    
    categories: Category[] = [];
    products: Product[] = [];

    async mounted() {
        this.products = await RefData.getProductsAll();
        this.categories = await RefData.getAllCategories();
    }
    
}