const gulp = require('gulp');
var size = require('gulp-size');

gulp.task('css', () => {
    const postcss = require('gulp-postcss');

    return gulp.src('./styles/site.css')
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer'),
            require('cssnano'),

        ]))

        .pipe(size({ title: 'CSS', gzip: true, showFiles: true }))
        .pipe(gulp.dest('./wwwroot/css/'));
});

const brotliCompress = () => {
    const postcss = require('gulp-postcss');
    const brotli = require('gulp-brotli');
    let src = "./styles/site.css",
        dest = "./wwwroot/css/";

    return gulp.src(src)
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer'),
            require('cssnano'),

        ]))
        .pipe(brotli.compress({
            quality: 11
        }))
        .pipe(gulp.dest(dest));
};

exports.brotliCompress = brotliCompress;