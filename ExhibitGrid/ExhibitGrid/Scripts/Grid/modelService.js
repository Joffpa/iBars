/// <reference path="../typings/lodash/lodash.d.ts" />
'use strict';
var app;
(function (app) {
    var model;
    (function (model) {
        var ExhibitVm = (function () {
            function ExhibitVm(ExhibitCode) {
                this.ExhibitCode = ExhibitCode;
                this.Grids = new Array();
            }
            return ExhibitVm;
        })();
        model.ExhibitVm = ExhibitVm;
        var GridVm = (function () {
            function GridVm(GridCode) {
                this.GridCode = GridCode;
            }
            return GridVm;
        })();
        model.GridVm = GridVm;
        var RowVm = (function () {
            function RowVm(RowCode, Class, Text, CanCollapse, CanSelect, IsSelected) {
                this.RowCode = RowCode;
                this.Class = Class;
            }
            return RowVm;
        })();
        model.RowVm = RowVm;
        var CellVm = (function () {
            function CellVm(Order, Type, RowCode, ColCode, CanAddNarrative, HasNarrative) {
                this.RowCode = RowCode;
                this.ColCode = ColCode;
            }
            return CellVm;
        })();
        model.CellVm = CellVm;
        var CalcExpressionVm = (function () {
            function CalcExpressionVm() {
            }
            return CalcExpressionVm;
        })();
        model.CalcExpressionVm = CalcExpressionVm;
        var CalcOperandVm = (function () {
            function CalcOperandVm() {
            }
            return CalcOperandVm;
        })();
        model.CalcOperandVm = CalcOperandVm;
        var MockModelService = (function () {
            function MockModelService() {
                this.exhibitModel = new ExhibitVm("Test Exhibit");
                this.addGridVm(window['gridModel'].grid);
            }
            MockModelService.prototype.addGridVm = function (gridVm) {
                this.exhibitModel.Grids.push(gridVm);
            };
            MockModelService.prototype.getExhibitVm = function () {
                return this.exhibitModel;
            };
            MockModelService.prototype.getGridVm = function (gridCode) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                return grid;
            };
            MockModelService.prototype.getRowVm = function (gridCode, rowCode) {
                console.log(gridCode);
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                var row = _.find(grid.DataRows, { 'RowCode': rowCode });
                return row;
            };
            MockModelService.prototype.getCellVm = function (gridCode, rowCode, colCode) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                var row = _.find(grid.DataRows, { 'RowCode': rowCode });
                var cell = _.find(row.Cells, { 'ColCode': colCode });
                return cell;
            };
            MockModelService.prototype.updateCellValue = function (gridCode, rowCode, colCode, value) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                var row = _.find(grid.DataRows, { 'RowCode': rowCode });
                var cell = _.find(row.Cells, { 'ColCode': colCode });
                cell.NumValue = value;
            };
            MockModelService.prototype.getCellValue = function (gridCode, rowCode, colCode) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                var row = _.find(grid.DataRows, { 'RowCode': rowCode });
                var cell = _.find(row.Cells, { 'ColCode': colCode });
                return cell.NumValue;
            };
            MockModelService.prototype.collapseChildren = function (gridCode, rowCode) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                _.each(_.where(grid.DataRows, { 'ParentRowCode': rowCode }), function (child) {
                    child.IsCollapsed = !child.IsCollapsed;
                });
            };
            MockModelService.prototype.getParentRowCalcForColumn = function (gridCode, parentRowCode, colCode) {
                var calc = "";
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                _.each(_.where(grid.DataRows, { 'ParentRowCode': parentRowCode }), function (child) {
                    var cell = _.find(child.Cells, { 'ColCode': colCode });
                    calc += cell.NumValue.toString() + "+";
                });
                if (calc && calc.length > 2) {
                    calc.substring(0, calc.length - 2);
                }
                else {
                    calc = "0";
                }
                return calc;
            };
            return MockModelService;
        })();
        model.MockModelService = MockModelService;
        var service = angular
            .module('app.model', [])
            .service('modelService', MockModelService);
    })(model = app.model || (app.model = {}));
})(app || (app = {}));
//# sourceMappingURL=modelService.js.map