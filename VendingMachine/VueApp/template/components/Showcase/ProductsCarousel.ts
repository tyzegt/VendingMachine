import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";
import { VueperSlides, VueperSlide } from 'vueperslides';
import Category from "@/template/models/Category";
import Product from "@/template/models/Product";
import { BIconCart4 } from 'bootstrap-vue';
import RefData from "@/template/util/RefData";


@Component({
    components: {
        VueperSlides, VueperSlide, BIconCart4
    }
})
export default class ProductsCarousel extends Vue {
    
    @Prop() category!: Category;
    products: Product[] = [];
    loading: boolean = true;

    mounted() {
        console.log("ProductsCarousel mounted");
        this.getProducts();
    }

    getProducts() {
        RefData.getProductsByCategory(this.category.id).then(result => {
            this.products = result;
        });
    }

    buy(product: Product) {
        if(product.count > 0 && this.$store.state.totalSum >= product.price) {
            axios.post("/Product/Buy?productId=" + product.id).then(result => {
                if(result.data) {
                    this.$emit("purchased", product);
                    this.getProducts();
                }
            })
            .catch(error => {
                console.log(error.response);
            }); 
        }
    }

    isButtonDisabled(product: Product) {
        return !product.isAvailable || product.count == 0 || product.price > this.$store.state.totalSum;
    }
}