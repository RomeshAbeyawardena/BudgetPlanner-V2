const budgetCardComponent = (vueInstance) => {
    return {
        template: require('./../../components/budget-card.html'),
        props: {
            budgetItem: Object,
            viewMode: String
        },
        watch: {
            budgetItem(newValue) {
                vueInstance.set(this, 'budget', newValue);
            }
        },
        methods: {
            viewBudget: function (id) {
                this.$emit("budget:view", id);
            }
        },
        computed: {
            isListViewMode: function () {
                return this.mode === 'list';
            },
            isDetailsViewMode: function () {
                return this.mode === 'details';
            }
        },
        data: function () {
            return {
                mode: this.viewMode,
                budget: this.budgetItem
            }
        }
    }
}

export default budgetCardComponent;