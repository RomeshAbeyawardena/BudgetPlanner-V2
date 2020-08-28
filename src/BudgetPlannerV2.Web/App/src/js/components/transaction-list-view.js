import Vuex from 'vuex';

const transactionListViewComponent = (vueInstance) => {
    return {
        template: require('./../../components/transaction-list-view.html'),
        props: {
            budgetItem: Object,
            transactionItems: Array
        },
        watch: {
            budgetItem: function (newValue) {
                vueInstance.set(this, 'budget', newValue);
            },
            transactionItems: function (newValue) {
                vueInstance.set(this, 'transactions', newValue);
            }
        },
        data: function () {
            return {
                budget: this.budgetItem,
                transactions: this.transactionItems
            }
        },
        computed: {
            ...Vuex.mapGetters(['isTransactionsLoaded'])
        }
    }
}

export default transactionListViewComponent;