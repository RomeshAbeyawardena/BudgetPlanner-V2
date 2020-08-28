import Vue from "vue";
import Vuex from "vuex";
import registerComponents from "./../components";
import modules from "./../modules";

Vue.use(Vuex);
const vueHelper = registerComponents(Vue);

const store = new Vuex.store({
    modules: modules(Vue),
    actions: {
        
    }
});

const app = {
    init(element) {
        this.instance = new Vue({
            el: element,
            store: store
        }) 
    },
    Helper: vueHelper,
    instance: null
}

export default app;