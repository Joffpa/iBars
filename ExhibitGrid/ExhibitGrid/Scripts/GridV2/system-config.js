//Testing various configs
System.config({
    defaultJSExtensions: true,
    packages: {
        'angular2': {
            defaultExtension: false
        },
        'rxjs': {
            defaultExtension: false
        }
    }
});

System.import('/Scripts/main.js');
