import utility from "./../utility";

import spinnerLoaderComponent from "./spinner-loader";
import budgetCardComponent from "./budget-card";
import budgetListComponent from "./budget-list";
import transactionListViewComponent from "./transaction-list-view";

const registerComponents = (vueInstance) => {
    return new utility.VueHelper(vueInstance)
        .registerComponent("spinner-loader", spinnerLoaderComponent(vueInstance))
        .registerComponent("budget-card", budgetCardComponent(vueInstance))
        .registerComponent("budget-list", budgetListComponent(vueInstance))
        .registerComponent("transaction-list-view", transactionListViewComponent(vueInstance));
}

export default registerComponents;