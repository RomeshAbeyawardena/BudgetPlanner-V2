import currencyFilter from "./currency";
import dateFilter from "./date";

const registerFilters = (vueHelper) => {
    vueHelper
        .registerFilter("currency", currencyFilter)
        .registerFilter("date", dateFilter);
}

export default registerFilters;