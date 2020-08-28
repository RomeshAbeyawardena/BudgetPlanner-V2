import Vue from "vue";
import Vuex from "vuex";
import registerComponents from "./../components";
import modules from "./../modules";
import registerFilters from "./../filters";
Vue.use(Vuex);

const vueHelper = registerComponents(Vue);
registerFilters(vueHelper);

const store = new Vuex.Store({
    modules: modules(Vue),
    actions: {
        
    }
});

const app = {
    init(element) {
        this.instance = new Vue({
            el: element,
            store: store,
            data: function () {
            return {
                menuExpanded: false,
                showDetails: false,
                currentBudget: { transactions: [] }
            }
        },
        computed: {
            menuNavCss: function() {
                if (this.menuExpanded) {
                    return "navbar-collapse";
                }
                else {
                    return "collapse navbar-collapse";
                }
            },
            ...Vuex.mapGetters(['budgets', 'transactions', 'budgetById'])
        },
        methods: {
            ...Vuex.mapActions(['loadBudget', 'loadTransactions', 'resetFlags']),
            expandTransactions: function (id) {
                var context = this;
                Vue.set(this, "showDetails", true);
                this.loadTransactions(id).then(function () {
                    Vue.set(context, 'currentBudget', context.budgetById(id));
                    Vue.set(context.currentBudget, 'transactions', context.transactions(id));
                })
                
            },
            refresh: function () {
                this.resetFlags();
                this.loadBudget();
                Vue.set(this, 'showDetails', false);
            },
            onBlur: function () {
                var context = this;
                window.setTimeout(function () {
                    context.toggleMenu(false);
                }, 50)
                
            },
            toggleMenu: function (value) {

                if (value === null) {
                    value = !this.menuExpanded;
                }

                Vue.set(this, 'menuExpanded', value);
            },
            goBack: function () {
                Vue.set(this, 'currentBudget', { transactions: [] });
                Vue.set(this, "showDetails", false);
            }
        },
        created: function () {
            this.loadBudget();
        }
        }) 
    },
    Helper: vueHelper,
    instance: null
}

export default app;