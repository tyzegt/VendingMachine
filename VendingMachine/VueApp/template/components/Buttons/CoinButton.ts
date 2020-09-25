import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";


@Component({
    components: {
        
    }
})
export default class CoinButton extends Vue {
        
    mounted() {
        console.log("CoinButton mounted");
    }
}