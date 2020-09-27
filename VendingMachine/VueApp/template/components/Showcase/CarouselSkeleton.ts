import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";
import { VueperSlides, VueperSlide } from 'vueperslides';
import Category from "@/template/models/Category";


@Component({
    components: {
        VueperSlides, VueperSlide
    }
})
export default class CarouselSkeleton extends Vue {
    
    @Prop() category!: Category;

    mounted() {
        console.log("CarouselSkeleton mounted");
    }

}