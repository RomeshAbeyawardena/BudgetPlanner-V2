import jsonWebToken from 'jsonwebtoken';
import Promise from 'promise';

export const jsonWebTokenHelper = {
    decode(token, key) {
        return new Promise((resolve, reject) => {
            jsonWebToken.verify(token, key, (err, decoded) => {
                if (decoded) {
                    resolve(decoded);
                    return;
                }

                reject(err);
            });
        });
    },
    sign(value, key, options) {
        return new Promise((resolve, reject) => {
            jsonWebToken.sign(value, key, options, (err, token) => {
                if (token) {
                    resolve(token);
                    return;
                }

                reject(err);
            });
        });
    }
}