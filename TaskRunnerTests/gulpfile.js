/// <binding AfterBuild='min' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

"use strict";

var gulp = require('gulp');
var cssmin = require("gulp-cssmin");
var jsUglify = require("gulp-uglify");

var fs = require('fs');

var json = fs.readFileSync("./gulp-config.json", "utf8");
var host = JSON.parse(json.replace(/^\uFEFF/, ''));

host.isDebug = host.config == "Debug";
host.isStaging = host.config == "Staging";
host.isRelease = host.config == "Release";

var paths = {
    css: "./Content/*.css",
    js: "./Scripts/*.js"
};

gulp.task("min:css", function () {
    return gulp.src([paths.css])
      .pipe(cssmin())
      .pipe(gulp.dest("./Content/"));
});

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!./Scripts/_references.js"])
      .pipe(jsUglify())
      .pipe(gulp.dest("./Scripts/"));
});

var tasks = [];

if (host.isRelease) {
    tasks = ["min:css", "min:js"];
}

gulp.task("min", tasks);