
(function (gbl) {

    var app = './wwwroot/app/';
    var temp = './tmp';
    var wiredep = require('wiredep');
    var npmFiles = wiredep({ devDependencies: true })['js'];
    var specRunnerFile = 'specs.html',

    var config = {
        alljs: ['./wwwroot/**/*.js', './*.js'],
        build: './build',
        app: app,
        css: temp + 'app.css',
        fonts: ['./wwwroot/font-awesome/fonts/**/*.*', './wwwroot/bootstrap/fonts/**/*.*'],
        images: app + 'images/**/*.*',
        index: app + 'index.html',
        js: [app + '**/*.module.js', app + '**/*.js', '!', app + '**/*.spec.js'],
        less: app + 'styles/app.less',
        html: app + '**/*.html',
        root: root,
        report: report,
        temp: temp,
        optimized: {
            app: 'app.js',
            lib: 'lib.js'
        },
        npmLocations: {
            json: require('./package.json'),
            directory: './node_modules/',
            ignorePath: '../..'
        },
        packages: ['./package.json'],
        specRunner: app + specRunnerFile,
        specRunnerFile: specRunnerFile,
        testLibraries: [
            'node_modules/mocha/mocha.js',
            'node_modules/chai/chai.js',
            'node_modules/mocha-clean/index.js',
            'node_modules/sinon-chai/lib/sinon-chai.js'
        ],

        specs: [app + '**/*.spec.js'],

        // karma and testing settings
        specHelpers: [app + 'test-helpers/*.js'],
        serverIntegrationSpecs: [app + 'tests/server-integration/**/*.spec.js']
    };

    config.getWiredepDefaultOptions = function () {
        var options = {
            packageJson: config.npmLocations.json,
            directory: config.npmLocations.directory,
            ignorePath: config.npmLocations.ignorePath
        };

        return options;
    };

    config.karma = getKarmaOptions();

    return config;

    function getKarmaOptions() {

        var options = {
            files: [].concat(
                npmFiles,
                config.specHelpers,
                app + '**/*.module.js',
                app + '**/*.js',
                temp + config.serverIntegrationSpecs
            ),
            exclude: [],
            coverage: {
                dir: report + 'coverage',
                reporters: [
                    { type: 'html', subdir: 'report-html' },
                    { type: 'lcov', subdir: 'report-lcov' },
                    { type: 'text-summary' }
                ]
            },
            preprocessors: {}
        };

        options.preprocessors[app + '**/!(*.spec)+(js)'] = ['coverage'];

        return options;
    }
})(this);