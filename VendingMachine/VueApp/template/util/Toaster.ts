import Vue from "vue";

export default class Toaster extends Vue {
    
    public static toast(bvToast: any, message: string, title: string, variant: string) {
        bvToast.toast(message, {
          title: title,
          variant: variant,
          toaster: 'b-toaster-bottom-right',
          solid: true,
          appendToast: false
        })
    }

}