const spinnerLoader = (vueInstance) => {
    return {
        template: require('./../../components/spinner-loader.html'),
        props: {
            isLoading: true
        },
        watch: {
            isLoading: function (newValue) {
                vueInstance.set(this, "loading", newValue);
            }
        },
        data: function () {
            return {
                loading: this.isLoading 
            }
        }
    }
}

export default spinnerLoader;