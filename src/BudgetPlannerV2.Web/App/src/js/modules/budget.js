import services from "./../services";

const budgetModule = (vueInstance) => {
    return {
        state: {
            budgetsLoaded: false,
            budgets: [],
        },
        mutations: {
            setBudgetsLoadedFlag(state, value) {
                state.budgetsLoaded = value;
            },
            loadBudget(state, budgets) {
                vueInstance.set(state, "budgets", budgets);
            }
        },
        actions: {
            loadBudget({ state, commit }) {
                return new Promise(function (resolve, reject) {

                    if (state.budgetsLoaded) {
                        resolve(state.budgets);
                        return;
                    }

                    services.budgetService
                        .getBudgets()
                        .then(() => {
                            commit("loadBudget", response.data);
                            commit("setBudgetsLoadedFlag", true);
                            resolve(response.data);
                        });
                });
            },
            resetBudgetFlags({ commit }) {
                commit("setBudgetsLoadedFlag", false);
            }
        },
        getters: {
            isBudgetLoaded(state) {
                return state.budgetsLoaded;
            },
            budgets(state) {
                return state.budgets;
            },
            budgetById(state) {
                return (budgetId) => {
                    return state.budgets.find(function (budget) {
                        return budget.id === budgetId;
                    })
                }
            }
        }
    }
}

export default budgetModule;