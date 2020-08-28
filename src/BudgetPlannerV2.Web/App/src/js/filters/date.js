import moment from "moment";

const dateFilter = (value, format) => {
    return moment(value).format(format);
}

export default dateFilter;