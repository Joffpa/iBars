'use strict';
var app;
(function (app) {
    var ExhibitController = (function () {
        function ExhibitController(modelService) {
            this.modelService = modelService;
            this.exhibitVm = modelService.getExhibitModel();
            this.currentGridVm = modelService.getGridModel('Grid_A');
            //console.log(this.curentGridVm);
        }
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
        RowController.prototype.getRowCssClass = function () {
            if (this.RowVm.Type == 0 /* Data */)
                return 'data-row';
            else if (this.RowVm.Type == 1 /* Total */)
                return 'total-row';
            else if (this.RowVm.Type == 2 /* Header */)
                return 'header-row';
        };
        RowController.prototype.addRow = function () {
            alert('row added' + this.RowVm.RowCode);
        };
        return RowController;
    })();
    app.RowController = RowController;
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