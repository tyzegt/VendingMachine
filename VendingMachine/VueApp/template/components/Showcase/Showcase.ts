import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";


@Component({
    components: {
        
    }
})
export default class Showcase extends Vue {
    
    
    mounted() {
        console.log("Showcase mounted");
    }
}