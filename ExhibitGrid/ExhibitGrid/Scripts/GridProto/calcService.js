/// <reference path="../typings/angularjs/angular.d.ts" />
(function () {
    //'use strict'
    var service = angular.module('exhibitGrid.calc', ['exhibitGrid.modelService']);
    service.factory('calcService', ['gridModelService', function (gridModelService) {
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
})();
