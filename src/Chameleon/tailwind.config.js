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
     fill: theme => ({
            'red': theme('colors.red.500'),
            'green': theme('colors.green.500'),
            'blue': theme('colors.blue.500'),
        })
    },
    variants: {
        extend: {
            fill: ['hover', 'focus'],
        },
    },
    plugins: [require('daisyui')
    ],
}
