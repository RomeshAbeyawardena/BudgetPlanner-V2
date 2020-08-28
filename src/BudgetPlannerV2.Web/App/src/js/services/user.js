import utility from "../utility"

export const userService = {
    getUserFromToken(token, key) {
        utility.jsonWebTokenHelper.decode(token, key)
            .then((e) => {
                return e;
            })
    }
}