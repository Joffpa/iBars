/// <reference path="../typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var calc;
    (function (calc) {
        'use strict';
        var service = angular.module('app.calc', ['app.model']);
        service.factory('calcService', ['modelService', function (modelService) {
                var calcVm = {
                    RowCalcs: ['Row_1']
                };
                function getIndependantCells() {
                    //_(calcVm.RowCalcs).forEach(function(n){
                    //    return gridModelService.getChildRows(n, )
                    //});                      
                }
                return {
                    isCellIndependantVariable: function (cellIdentifier) {
                        //_(calcVm.RowCalcs).forEach(function (n) {
                        //    return gridModelService.getChildRows(n, )
                        //});
                    },
                    callDependantCalcs: function (cellIdentifier) {
                    }
                };
            }]);
    })(calc = app.calc || (app.calc = {}));
})(app || (app = {}));
//# sourceMappingURL=calcService.js.map