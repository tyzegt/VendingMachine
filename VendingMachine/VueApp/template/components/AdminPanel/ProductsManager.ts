import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import RefData from "@/template/util/RefData";
import Product from "@/template/models/Product";


@Component({
    components: {
    }
})
export default class ProductsManager extends Vue {
    
    products: Product[] = [];

    async mounted() {
        this.products = await RefData.getProductsAll();
        console.log("Products", this.products);
    }
    
}