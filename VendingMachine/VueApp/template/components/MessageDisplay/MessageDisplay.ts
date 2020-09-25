import Vue from "vue";
import { Component, Prop} from "vue-property-decorator";
import axios from "axios";


@Component({
    components: {
        
    }
})
export default class MessageDisplay extends Vue {
    
    @Prop() message!: string;
    
    mounted() {
        console.log("MessageDisplay mounted");
    }
}