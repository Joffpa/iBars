/// <reference path="../typings/lodash/lodash.d.ts" />
'use strict';
var app;
(function (app) {
    var model;
    (function (model) {
        var ExhibitVm = (function () {
            function ExhibitVm() {
                this.Grids = new Array();
            }
            return ExhibitVm;
        }());
        model.ExhibitVm = ExhibitVm;
        var GridVm = (function () {
            function GridVm(GridCode) {
                this.GridCode = GridCode;
            }
            return GridVm;
        }());
        model.GridVm = GridVm;
        var RowVm = (function () {
            function RowVm(RowCode, Class, Text, CanCollapse, CanSelect, IsSelected) {
                this.RowCode = RowCode;
                this.Class = Class;
            }
            return RowVm;
        }());
        model.RowVm = RowVm;
        var CellVm = (function () {
            function CellVm(Order, Type, RowCode, ColCode, CanAddNarrative, HasNarrative) {
                this.RowCode = RowCode;
                this.ColCode = ColCode;
            }
            return CellVm;
        }());
        model.CellVm = CellVm;
        var CalcExpressionVm = (function () {
            function CalcExpressionVm() {
            }
            return CalcExpressionVm;
        }());
        model.CalcExpressionVm = CalcExpressionVm;
        var CalcOperandVm = (function () {
            function CalcOperandVm() {
            }
            return CalcOperandVm;
        }());
        model.CalcOperandVm = CalcOperandVm;
        var ModelService = (function () {
            //collapseChildren(gridCode: string, rowCode: string) {
            //    var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            //    _.each(_.where(grid.Rows, { 'ParentRowCode': rowCode }), child => {
            //        child.IsCollapsed = !child.IsCollapsed;
            //    });
            //}
            //getParentRowCalcForColumn(gridCode: string, parentRowCode: string, colCode) {
            //    var calc = "";
            //    var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            //    _.each(_.where(grid.Rows, { 'ParentRowCode': parentRowCode }), child => {
            //        var cell = _.find(child.Cells, { 'ColCode': colCode });
            //        calc += cell.NumValue.toString() + "+";
            //    });
            //    if (calc && calc.length > 2) {
            //        calc.substring(0, calc.length - 2);
            //    } else {
            //        calc = "0";
            //    }
            //    return calc;
            //}
            function ModelService() {
                this.exhibitModel = window['gridModel'].exhibit;
            }
            ModelService.prototype.addGridVm = function (gridVm) {
                this.exhibitModel.Grids.push(gridVm);
            };
            ModelService.prototype.getExhibitVm = function () {
                return this.exhibitModel;
            };
            ModelService.prototype.getGridVm = function (gridCode) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                return grid;
            };
            ModelService.prototype.getRowVm = function (gridCode, rowCode) {
                var grid = this.getGridVm(gridCode);
                var row = _.find(grid.Rows, { 'RowCode': rowCode });
                return row;
            };
            ModelService.prototype.getCellVm = function (gridCode, rowCode, colCode) {
                var row = this.getRowVm(gridCode, rowCode);
                var cell = _.find(row.Cells, { 'ColCode': colCode });
                return cell;
            };
            ModelService.prototype.updateCellValue = function (gridCode, rowCode, colCode, value) {
                var cell = this.getCellVm(gridCode, rowCode, colCode);
                cell.NumValue = value;
                cell.Value = value.toString();
            };
            ModelService.prototype.setCellValueNA = function (gridCode, rowCode, colCode) {
                var cell = this.getCellVm(gridCode, rowCode, colCode);
                cell.Value = "N/A";
                cell.NumValue = 0;
            };
            ModelService.prototype.getCellValueForCalc = function (gridCode, rowCode, colCode) {
                var cell = this.getCellVm(gridCode, rowCode, colCode);
                if (cell.Type == 'percent') {
                    return cell.NumValue / 100;
                }
                return cell.NumValue;
            };
            return ModelService;
        }());
        model.ModelService = ModelService;
        var service = angular
            .module('app.model', [])
            .service('modelService', ModelService);
    })(model = app.model || (app.model = {}));
})(app || (app = {}));
//# sourceMappingURL=modelService.js.map