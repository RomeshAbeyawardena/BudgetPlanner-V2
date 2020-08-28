import services from "./../services";

const transactionModule = (vueInstance) => {
    return {
        state: {
            transactionsLoaded: false,
            transactions: []
        },
        mutations: {
            setBudgetsLoadedFlag(state, value) {
                state.budgetsLoaded = value;
            },
            setTransactionsLoadedFlag(state, value) {
                state.transactionsLoaded = value;
            },
            loadTransactions: function (state, transactions) {
                vueInstance.set(state, "transactions", transactions);
            }
        },
        actions: {
            loadTransactions: function ({ state, commit }, id) {
                return new Promise(function (resolve, reject) {

                    if (state.transactionsLoaded) {
                        resolve(state.transactions);
                        return;
                    }

                    services.transactionService
                        .getTransactions
                        .then(() => {
                            commit("loadTransactions", budgetTransactionResponse.data);
                            commit("setTransactionsLoadedFlag", true);
                            resolve(budgetTransactionResponse.data);
                        });
                });
            },
            resetTransactionFlags: function ({ commit }) {
                commit("setTransactionsLoadedFlag", false);
            }
        },
        getters: {
            isTransactionsLoaded: function (state) {
                return state.transactionsLoaded;
            },
            transactions: function (state) {
                return function (budgetId) {
                    return state.transactions.filter(function (t) { return t.budgetId === budgetId });
                }
            }
        }
    }
}

export default transactionModule;