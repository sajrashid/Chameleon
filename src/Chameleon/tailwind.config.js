const plugin = require("tailwindcss/plugin");
const selectorParser = require("postcss-selector-parser");
const colors = require('tailwindcss/colors')
module.exports = {
  purge: {
    enabled: true,
    content: [

        './**/*.html',
        './**/*.razor'
        ],
        options: {
            safelist: [
                /data-theme$/,
            ]
        },
    },
    daisyui: {
        styled: true,
        themes: true,
        rtl: false,
    },
    darkMode: 'class', // false or 'media'
    theme: {
        extend: {
            colors: {
                lime: colors.lime,
                emerald: colors.emerald
            },
        },
    },
    variants: {
        extend: {},
    },
    plugins: [require('daisyui')
    ],
}
