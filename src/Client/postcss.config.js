const cssnano = require('cssnano')
module.exports = {
    plugins: [
        require('tailwindcss')('tailwind.config.js'),
        require('autoprefixer'),
        cssnano({
            preset: 'default'
        })
    ]
}