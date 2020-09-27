import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";
import { VueperSlides, VueperSlide } from 'vueperslides';
import Category from "@/template/models/Category";


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
        axios.get("/Category/GetCategories").then(result => {
            this.categories = result.data;
            console.log(this.categories);
        })
        .catch(error => {
            console.log(error.response);
        });
    }
}