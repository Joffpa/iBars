/// <reference path="../typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var calc;
    (function (calc) {
        'use strict';
        var CalcService = (function () {
            function CalcService(modelService) {
            }
            return CalcService;
        })();
        calc.CalcService = CalcService;
        var service = angular.module('app.calc', ['app.model']);
        service.factory('calcService', ['modelService', function (modelService) {
                return new CalcService(modelService);
            }]);
    })(calc = app.calc || (app.calc = {}));
})(app || (app = {}));
//# sourceMappingURL=calcService.js.map