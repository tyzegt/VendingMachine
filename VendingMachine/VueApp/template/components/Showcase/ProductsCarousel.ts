import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";
import { VueperSlides, VueperSlide } from 'vueperslides';
import Category from "@/template/models/Category";
import Product from "@/template/models/Product";
import { BIconCart4 } from 'bootstrap-vue';


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
        axios.get("/Product/GetByCategory?categoryId=" + this.category.id).then(result => {
            this.products = result.data;
            console.log(this.products);
        })
        .catch(error => {
            console.log(error.response);
        }); 
    }
}