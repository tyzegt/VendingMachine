import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import RefData from "@/template/util/RefData";
import Category from "@/template/models/Category";


@Component({
    components: {
    }
})
export default class CategoriesManager extends Vue {
    
    categories: Category[] = [];
    
    async mounted() {        
        this.categories = await RefData.getCategories();
        console.log("cats", this.categories);
    }
    
}