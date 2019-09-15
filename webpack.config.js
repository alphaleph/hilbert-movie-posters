const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const isDevelopment = process.env.NODE_ENV === 'development';

module.exports = {
    mode: 'development',
    devtool: 'eval-source-map',
    entry: { 'main': './wwwroot/src/app.tsx' },
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js',
        publicPath: 'dist/'
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: isDevelopment ? '[name].css' : '[name].[hash].css',
            chunkFilename: isDevelopment ? '[id].css' : '[id].[hash].css'
        }),

    ],
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: [
                            "@babel/preset-react",
                            "@babel/preset-typescript",
                            [
                                "@babel/preset-env", {
                                    targets: { 
                                       "browsers": ["last 2 versions"]
                                    },
                                    modules: false,
                                    useBuiltIns: "usage",
                                    corejs: 3
                                }
                            ]
                        ]
                    }
                }
            },
            {
                test: /\.jsx?$/,
                use: ["source-map-loader"],
                enforce: "pre"
            },
            {
                test: /\.s(a|c)ss$/,
                loader: [
                    isDevelopment ? 'style-loader' : MiniCssExtractPlugin.loader,
                    'css-loader',
                    'postcss-loader',
                    {
                        loader: 'sass-loader',
                        options: {
                            sourceMap: isDevelopment
                        }
                    }
                ]
            },
            {
                test: /\.(png|svg|jpe?g|gif)$/,
                use: [
                    'file-loader'
                ]
            }
        ]
    },
    resolve: {
        extensions: ['.js', '.jsx', ".tsx", ".ts", '.scss']
    }
};