'use strict';
var app;
(function (app) {
    var v2;
    (function (v2) {
        var GridController = (function () {
            function GridController(modelService) {
                this.GridVm = modelService.getGridVm('MockGrid');
                console.log(this.GridVm);
                this.ModelService = modelService;
            }
            return GridController;
        })();
        v2.GridController = GridController;
        var RowController = (function () {
            function RowController($scope, modelService) {
                this.RowVm = $scope.row;
                this.ModelService = modelService;
            }
            RowController.prototype.addRow = function () {
                alert('row added: ' + this.RowVm.RowCode);
            };
            RowController.prototype.deleteRow = function () {
                alert('row deleted: ' + this.RowVm.RowCode);
            };
            return RowController;
        })();
        v2.RowController = RowController;
        //export class CellController {
        //    DataCellVm: app.v2.model.DataCellVm;
        //    CalcService: app.v2.calc.CalcService;
        //    constructor($scope, calcService: app.calc.CalcService) {
        //        this.DataCellVm = $scope.cell;
        //        this.CalcService = calcService;
        //    }
        //}
        var exhibitApp = angular
            .module('app.v2', ['app.v2.model', 'app.v2.directives'])
            .controller('gridController', ['modelService', GridController])
            .controller('rowController', ['$scope', 'modelService', RowController]);
    })(v2 = app.v2 || (app.v2 = {}));
})(app || (app = {}));
//# sourceMappingURL=grid.v2.js.map