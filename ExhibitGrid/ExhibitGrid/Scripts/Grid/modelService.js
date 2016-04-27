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
            ModelService.prototype.getRowVms = function (gridCode, rowCodes) {
                var grid = this.getGridVm(gridCode);
                return _.filter(grid.Rows, function (r) { return _.includes(rowCodes, r.RowCode); });
            };
            ModelService.prototype.getCellVm = function (gridCode, rowCode, colCode) {
                var row = this.getRowVm(gridCode, rowCode);
                var cell = _.find(row.Cells, { 'ColCode': colCode });
                return cell;
            };
            ModelService.prototype.updateCellValue = function (gridCode, rowCode, colCode, value) {
                var cell = this.getCellVm(gridCode, rowCode, colCode);
                this.updateCellVmValue(cell, value);
            };
            ModelService.prototype.updateCellVmValue = function (cellVm, value) {
                cellVm.Value = $.formatNumber(value.toString(), { format: "#,###.00", locale: "us" });
            };
            ModelService.prototype.setCellVmValueNA = function (cellVm) {
                cellVm.Value = "N/A";
            };
            ModelService.prototype.getCellValueForCalc = function (gridCode, rowCode, colCode) {
                var cellVm = this.getCellVm(gridCode, rowCode, colCode);
                return this.getCellValueForCalcFromVm(cellVm);
            };
            ModelService.prototype.getCellValueForCalcFromVm = function (cellVm) {
                //remove  comma formatting 
                var value = $.parseNumber(cellVm.Value, { format: "#,###.00", locale: "us" });
                var numValue = parseFloat(value);
                if (numValue === NaN) {
                    return NaN;
                }
                if (cellVm.DecimalPlaces) {
                    numValue = math.round(numValue, cellVm.DecimalPlaces);
                }
                if (cellVm.Type == 'percent') {
                    return numValue / 100;
                }
                return numValue;
            };
            ModelService.prototype.collapseChildren = function (gridCode, rowCode) {
                var _this = this;
                var row = this.getRowVm(gridCode, rowCode);
                row.CollapseableChildren.forEach(function (childRowCode) {
                    var childRow = _this.getRowVm(gridCode, childRowCode);
                    childRow.IsCollapsed = !childRow.IsCollapsed;
                });
            };
            ModelService.prototype.getCellStyle = function (cellVm) {
                var style = {};
                style['text-align'] = cellVm.Alignment;
                if (cellVm.Width) {
                    style['width'] = cellVm.Width;
                }
                else {
                    style['width'] = '100%';
                }
                return style;
            };
            ModelService.prototype.formatCellNumber = function (cellVm) {
                var value = cellVm.Value;
                //remove  comma formatting 
                value = $.parseNumber(cellVm.Value, { format: "#,###.00", locale: "us" });
                //conver to float
                var numValue = parseFloat(value);
                //if it is not a valid number, return without affecting any formatting
                if (numValue === NaN) {
                    return;
                }
                //Round decimals as neccesary
                if (cellVm.DecimalPlaces) {
                    numValue = math.round(numValue, cellVm.DecimalPlaces);
                }
                //re-apply comma formatting
                cellVm.Value = $.formatNumber(numValue.toString(), { format: "#,###.00", locale: "us" });
                if (cellVm.Value.charAt(0) === '.') {
                    cellVm.Value = "0" + cellVm.Value;
                }
            };
            ModelService.prototype.unformatCellNumber = function (cellVm) {
                if (cellVm.Value.match(/[a-z]/i)) {
                    // alphabet letters found, dont try to parse as a number
                    return;
                }
                var value = cellVm.Value;
                //remove comma formatting
                value = $.parseNumber(cellVm.Value, { format: "#,###.00000000", locale: "us" });
                //conver to float
                var numValue = parseFloat(value);
                //if it is not a valid number, return without affecting any formatting
                if (numValue === NaN) {
                    return;
                }
                //Round decimals as neccesary
                if (cellVm.DecimalPlaces) {
                    numValue = math.round(numValue, cellVm.DecimalPlaces);
                }
                //re-apply comma formatting
                cellVm.Value = numValue.toString();
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