const path = require('path');

module.exports = {
    entry: ['./src/index.js', './src/scss/index.scss'],
    mode: 'development',
    output: {
        filename: 'site.js',
        path: path.resolve(__dirname, '../wwwroot'),
    },
    module: {
        rules: [{
            test: /\.scss$/,
            use: [{
                loader: 'file-loader',
                options: {
                    name: "/styles.css"
                }
            },
            { loader: 'extract-loader' },
            { loader: 'css-loader?-url' },
            { loader: 'sass-loader' } 
            ]
        },
        {
            test: /\.js$/,
            use: [{
                loader: 'babel-loader',
                options: {
                    presets: ['@babel/preset-env']
                }
            }]
        },
        {
            test: /\.html$/,
            use: [
                { loader: 'html-loader' }
            ]
        }],
    },
    resolve: {
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        }
    }
};