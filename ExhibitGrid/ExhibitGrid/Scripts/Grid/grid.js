/// <reference path="../typings/angularjs/angular.d.ts" />
"use strict";
var app;
(function (app) {
    var GridController = (function () {
        function GridController(modelService) {
            this.ModelService = modelService;
            var gridCode = window["gridModel"].gridCode;
            this.GridVm = this.ModelService.getGridVm(gridCode);
        }
        return GridController;
    })();
    app.GridController = GridController;
    var RowController = (function () {
        function RowController($scope, modelService) {
            this.RowVm = $scope.row;
            this.ModelService = modelService;
        }
        RowController.prototype.collapseChildren = function () {
            this.ModelService.collapseChildren(this.RowVm.GridCode, this.RowVm.RowCode);
        };
        RowController.prototype.addRow = function () {
            alert('row added: ' + this.RowVm.RowCode);
        };
        RowController.prototype.deleteRow = function () {
            alert('row deleted: ' + this.RowVm.RowCode);
        };
        return RowController;
    })();
    app.RowController = RowController;
    var TextCellController = (function () {
        function TextCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        TextCellController.prototype.getStyle = function () {
            return { 'width': this.CellVm.Width };
        };
        return TextCellController;
    })();
    app.TextCellController = TextCellController;
    var NumericCellController = (function () {
        function NumericCellController($scope, modelService, calcService) {
            var _this = this;
            //console.log($scope);
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
            this.CalcService = calcService;
            if ((this.CellVm.Calcs && this.CellVm.Calcs.length > 0) || this.CellVm.ParentRowCode) {
                $scope.$watch('cellVm.NumValue', function (newVal, oldVal, scope) {
                    scope.cellCtrl.CalcService.runCellCalcs(_this.CellVm, newVal);
                });
            }
        }
        NumericCellController.prototype.getStyle = function () {
            if (this.CellVm.Width) {
                return { 'width': this.CellVm.Width };
            }
            return { 'width': '110px' };
        };
        return NumericCellController;
    })();
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
    })();
    app.PostItCellController = PostItCellController;
    var NarrativeCellController = (function () {
        function NarrativeCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
            //console.log($scope.cellVm);
        }
        NarrativeCellController.prototype.editNarrative = function () {
            alert(this.CellVm.Value);
        };
        return NarrativeCellController;
    })();
    app.NarrativeCellController = NarrativeCellController;
    var DropdownCellController = (function () {
        function DropdownCellController($scope, modelService) {
            this.CellVm = $scope.cellVm;
            this.ModelService = modelService;
        }
        return DropdownCellController;
    })();
    app.DropdownCellController = DropdownCellController;
    // ReSharper disable once TsResolvedFromInaccessibleModule
    var exhibitApp = angular
        .module('app', ['app.model', 'app.directives', 'app.calc', 'app.filters'])
        .controller('gridController', ['modelService', GridController])
        .controller('rowController', ['$scope', 'modelService', RowController]);
})(app || (app = {}));
//# sourceMappingURL=grid.js.map