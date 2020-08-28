import Vue from "vue";
import Vuex from "vuex";
import utility from "./../utility";

import budgetCardComponent from "./../components/budget-card";
import budgetListComponent from "./../components/budget-list";
import transactionListViewComponent from "./../components/transaction-list-view";

import modules from "./../modules";

Vue.use(Vuex);

const store = new Vuex.store({
    modules: modules,
    actions: {
        
    }
});

const vueHelper = new utility.vueHelper(Vue)
    .registerComponent("budget-card", budgetCardComponent)
    .registerComponent("budget-list", budgetListComponent)
    .registerComponent("transaction-list-view", transactionListViewComponent);

var app = {
    init(element) {
        this.instance = new Vue({
            el: element,
            store: store
        }) 
    },
    Helper: vueHelper,
    instance: null
}