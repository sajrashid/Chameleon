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