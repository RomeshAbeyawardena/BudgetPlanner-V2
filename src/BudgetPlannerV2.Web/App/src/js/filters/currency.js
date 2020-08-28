import accounting from "accounting";

const currencyFilter = (value) => {
    return accounting.formatMoney(value, String.fromCharCode(163));
}

export default currencyFilter;