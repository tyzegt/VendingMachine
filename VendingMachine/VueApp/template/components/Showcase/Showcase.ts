import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";
import { VueperSlides, VueperSlide } from 'vueperslides';
import Category from "@/template/models/Category";
import Product from "@/template/models/Product";
import RefData from "@/template/util/RefData";


@Component({
    components: {
        ProductsCarousel: require("@/template/components/Showcase/ProductsCarousel.vue").default,
        CarouselSkeleton: require("@/template/components/Showcase/CarouselSkeleton.vue").default,
        VueperSlides, VueperSlide
    }
})
export default class Showcase extends Vue {
    
    categories: Category[] = [];

    mounted() {
        console.log("Showcase mounted");
        this.loadCategories();
    }
    
    loadCategories() {
        RefData.getCategories().then(result => {
            this.categories = result;
            console.log("cats:", this.categories);
        });
    }

    purchased(product: Product) {
        this.$emit("purchased", product);
    }
}