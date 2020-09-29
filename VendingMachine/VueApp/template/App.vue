<template>
    <div>
        <div class="container">
            <router-view></router-view>
        </div>

        <div class="container">
            <footer>
                <hr />
                <p>&copy; 2020 - <a href="https://github.com/tyzegt">Торговый автомат</a></p>
            </footer>
        </div>

    </div>
</template>

<script lang="ts">

import { Vue, Component } from 'vue-property-decorator';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'vueperslides/dist/vueperslides.css';

@Component({
    components: {
        VendingMachine: require("@/template/components/VendingMachine/VendingMachine.vue").default,
    },
    name: 'App',
})
export default class App extends Vue { }
</script>

<style scoped lang="scss">
</style>
