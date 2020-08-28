import Vuex from 'vuex';

const budgetListComponent = (vueInstance) => {
    return {
        template: require('./../../components/budget-list.html'),
        props: {
            budgetItems: Array
        },
        watch: {
            budgetItems: function (newValue) {
                vueInstance.set(this, 'budgets', newValue);
            }
        },
        methods: {
            viewBudget: function (id) {
                this.$emit("view:budget", id)
            }
        },
        data: function () {
            return {
                budgets: this.budgetItems
            }
        },
        computed: {
            ...Vuex.mapGetters(['isBudgetLoaded'])
        }
    }
}

export default budgetListComponent;