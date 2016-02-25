var app;
(function (app) {
    var filters;
    (function (filters) {
        angular.module('app.filters', []).filter('negativeInParens', function () {
            return function (input) {
                if (input < 0) {
                    return '(' + Math.abs(input) + ')';
                }
                return input;
            };
        });
    })(filters = app.filters || (app.filters = {}));
})(app || (app = {}));
