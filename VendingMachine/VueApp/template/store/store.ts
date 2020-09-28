import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';
import { RootState } from './state';
import { vuexPageModule } from './modules/VueX/vuexpage-module';
import axios from "axios";

Vue.use(Vuex);

const store: StoreOptions<RootState> = {
    state: {
        version: '1.0.0',
        totalSum: 0
    },
    modules: {
        vuexPageModule
    }
};


export default new Vuex.Store<RootState>(store);
