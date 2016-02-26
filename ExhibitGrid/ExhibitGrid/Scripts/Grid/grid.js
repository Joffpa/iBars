'use strict';
var app;
(function (app) {
    var GridController = (function () {
        function GridController(modelService) {
            this.ModelService = modelService;
            var gridCode = window['gridModel'].gridCode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
        return GridController;
    }());
    app.GridController = GridController;
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
    }());
    app.RowController = RowController;
    var TextCellController = (function () {
        function TextCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        return TextCellController;
    }());
    app.TextCellController = TextCellController;
    var NumericCellController = (function () {
        function NumericCellController($scope, modelService, calcService) {
            console.log($scope);
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
            this.CalcService = calcService;
            if (this.CalcService.cellHasCalcs(this.CellVm.GridCode, this.CellVm.RowCode, this.CellVm.ColCode)) {
                $scope.$watch('cellVm.Value', function (newVal, oldVal, scope) {
                    scope.cellCtrl.CalcService.runCalcsForCell(scope.cellVm.GridCode, scope.cellVm.RowCode, scope.cellVm.ColCode, newVal);
                });
            }
        }
        return NumericCellController;
    }());
    app.NumericCellController = NumericCellController;
    var PostItCellController = (function () {
        function PostItCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        PostItCellController.prototype.editPostIt = function () {
            alert("Post it for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
        };
        return PostItCellController;
    }());
    app.PostItCellController = PostItCellController;
    var NarrativeCellController = (function () {
        function NarrativeCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        NarrativeCellController.prototype.editNarrative = function () {
            alert("Narrative for cell: " + this.CellVm.RowCode + " " + this.CellVm.ColCode);
        };
        return NarrativeCellController;
    }());
    app.NarrativeCellController = NarrativeCellController;
    var DropdownCellController = (function () {
        function DropdownCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        return DropdownCellController;
    }());
    app.DropdownCellController = DropdownCellController;
    var exhibitApp = angular
        .module('app', ['app.model', 'app.directives', 'app.calc', 'app.filters'])
        .controller('gridController', ['modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', RowController]);
})(app || (app = {}));
//# sourceMappingURL=grid.js.map