'use strict';
var app;
(function (app) {
    var ExhibitController = (function () {
        function ExhibitController(modelService) {
            this.modelService = modelService;
            this.exhibitVm = modelService.getExhibitModel();
            this.currentGridVm = modelService.getGridModel('MockGrid');
            //console.log(this.curentGridVm);
        }
        ExhibitController.prototype.getRowModel = function (gridCode, rowCode) {
            return this.modelService.getRowModel(gridCode, rowCode);
        };
        ExhibitController.prototype.ModifyFirstRow = function () {
            var row = this.modelService.getRowModel("MockGrid", "Row_0");
            row.SelectionCell.IncludeSpaceForCell = !row.SelectionCell.IncludeSpaceForCell;
        };
        return ExhibitController;
    })();
    app.ExhibitController = ExhibitController;
    var GridController = (function () {
        function GridController($scope, modelService) {
            this.GridVm = $scope.gridVm;
            this.ModelService = modelService;
        }
        return GridController;
    })();
    app.GridController = GridController;
    var RowController = (function () {
        function RowController($scope, modelService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
        }
        RowController.prototype.addRow = function () {
            alert('row added' + this.RowVm.RowCode);
        };
        return RowController;
    })();
    app.RowController = RowController;
    var IndependantRowController = (function () {
        function IndependantRowController($scope, modelService) {
            this.RowVm = $scope.rowVm;
            this.ModelService = modelService;
            console.log("i row ctrl const");
            console.log($scope);
        }
        return IndependantRowController;
    })();
    app.IndependantRowController = IndependantRowController;
    var CellController = (function () {
        function CellController($scope, calcService) {
            this.DataCellVm = $scope.cell;
            this.CalcService = calcService;
        }
        return CellController;
    })();
    app.CellController = CellController;
    var exhibitApp = angular.module('app', ['app.model', 'app.directives', 'app.calc']);
    exhibitApp.controller('exhibitController', ['modelService', ExhibitController]);
})(app || (app = {}));
//# sourceMappingURL=gridModule.js.map