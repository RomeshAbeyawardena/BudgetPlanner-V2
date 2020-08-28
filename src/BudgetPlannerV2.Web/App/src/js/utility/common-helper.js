﻿

export const commonHelper = {
    ready(callback) {
        if (document.readyState !== 'loading') {
            // Document is already ready, call the callback directly
            callback();
        } else if (document.addEventListener) {
            // All modern browsers to register DOMContentLoaded
            document.addEventListener('DOMContentLoaded', callback);
        } else {
            // Old IE browsers
            document.attachEvent('onreadystatechange', () => {
                if (document.readyState === 'complete') {
                    callback();
                }
            });
        }
    }
}