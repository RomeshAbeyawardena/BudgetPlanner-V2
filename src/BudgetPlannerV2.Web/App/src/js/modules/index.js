import budgetModule from "./budget";
import transactionModule from "./transaction"

const modules = (vueInstance) => {
    return {
        budget: budgetModule(vueInstance),
        transaction: transactionModule(vueInstance)
    }
}

export default modules;