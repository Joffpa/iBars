

module app.filters {

    angular.module('app.filters', []).filter('negativeInParens', function () {
        return function (input) {
            if (input < 0) {
                return '(' + Math.abs(input) + ')';
            }
            return input; 
        };
    });

}
