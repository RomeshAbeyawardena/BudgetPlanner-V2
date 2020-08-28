
export const VueHelper = function(vueInstance) {
    this.registerComponent = (componentName, configuration) => {
        vueInstance.component(componentName, configuration);
        return this;
    }

    this.registerFilter = (filterName, configuration) => {
        vueInstance.filter(filterName, configuration);
        return this;
    }
}