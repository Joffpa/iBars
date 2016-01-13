/// <reference path="../typings/lodash/lodash.d.ts" />
'use strict';
var app;
(function (app) {
    var model;
    (function (model) {
        (function (RowType) {
            RowType[RowType["Data"] = 0] = "Data";
            RowType[RowType["Total"] = 1] = "Total";
            RowType[RowType["Header"] = 2] = "Header";
        })(model.RowType || (model.RowType = {}));
        var RowType = model.RowType;
        (function (RowFunction) {
            RowFunction[RowFunction["Create"] = 0] = "Create";
            RowFunction[RowFunction["Delete"] = 1] = "Delete";
        })(model.RowFunction || (model.RowFunction = {}));
        var RowFunction = model.RowFunction;
        var GridVm = (function () {
            function GridVm() {
            }
            return GridVm;
        })();
        model.GridVm = GridVm;
        var RowVm = (function () {
            function RowVm() {
            }
            return RowVm;
        })();
        model.RowVm = RowVm;
        var CellVm = (function () {
            function CellVm() {
            }
            CellVm.prototype.getCoordinate = function () {
                return '{[' + this.RowCode + '][' + this.ColCode + ']}';
            };
            return CellVm;
        })();
        model.CellVm = CellVm;
        var MockModelService = (function () {
            function MockModelService() {
                //this.viewModel =  {
                //    Rows: [
                //        {
                //            RowCode: 'Row_0', RowParents: null, RowClass: 'header-row', RowText: 'Header Text',
                //            Cells: [
                //                { ColCode: 'Col_Txt', CellClass: 'blank-cell', CellType: 'text', CellValue: null, CellWidth: '2x', IsEditable: false },
                //                { ColCode: 'Col_A', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column A', CellWidth: '1x', IsEditable: false },
                //                { ColCode: 'Col_B', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column B', CellWidth: '1x', IsEditable: false },
                //                { ColCode: 'Col_C', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column C', CellWidth: '1x', IsEditable: false }
                //            ]
                //        },
                //        {
                //            RowCode: 'Row_1', RowParents: null, RowClass: 'total-row', RowText: 'Row 1 text',
                //            Cells: [
                //                { ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'text', CellWidth: '2x', IsEditable: false },
                //                { ColCode: 'Col_A', CellClass: 'data-cell', CellType: 'num', CellValue: 50, CellWidth: '1x', IsEditable: true },
                //                { ColCode: 'Col_B', CellClass: 'data-cell', CellType: 'num', CellValue: 100, CellWidth: '1x', IsEditable: true },
                //                { ColCode: 'Col_C', CellClass: 'data-cell', CellType: 'num', CellValue: 150, CellWidth: '1x', IsEditable: true }
                //            ]
                //        }
                //    ]
                //};
            }
            MockModelService.prototype.getGridModel = function (gridCode) {
                return this.viewModel[gridCode];
            };
            MockModelService.prototype.getChildRows = function (gridCode, rowCode, pluckProp) {
                var rows = _.where(this.viewModel[gridCode].Rows, { 'RowParents': [rowCode] });
                if (pluckProp) {
                    rows = _.pluck(rows, pluckProp);
                }
                return rows;
            };
            MockModelService.prototype.addAnotherRow = function (gridCode) {
                var rowNum = this.viewModel[gridCode].Rows.length;
                var cells = [];
                _.forEach(this.viewModel[gridCode].Rows[0].Cells, function (va, idx) {
                    if (idx === 0) {
                        cells.push({
                            ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'Row ' + rowNum, CellWidth: '2x'
                        });
                    }
                    else {
                        cells.push({
                            ColCode: 'Col_' + String.fromCharCode(idx + 64), CellClass: 'data-cell', CellType: 'num', CellValue: 500, CellWidth: '1x'
                        });
                    }
                });
                this.viewModel[gridCode].Rows.push({
                    RowCode: 'Row_' + rowNum, RowParents: null, RowClass: 'data-row', Cells: cells, RowText: 'Row ' + rowNum + ' Text'
                });
            };
            MockModelService.prototype.addAnotherColumn = function (gridCode) {
                var colLetter = String.fromCharCode(this.viewModel[gridCode].Rows[0].Cells.length + 64);
                _.forEach(this.viewModel[gridCode].Rows, function (val, idx) {
                    if (idx == 0) {
                        val.Cells.push({
                            ColCode: 'Col_' + colLetter, CellClass: 'header-cell', CellType: 'text', CellValue: 'Column ' + colLetter, CellWidth: '1x', IsEditable: false
                        });
                    }
                    else {
                        val.Cells.push({
                            ColCode: 'Col_' + colLetter, CellClass: 'data-cell', CellType: 'num', CellValue: 800, CellWidth: '1x', IsEditable: true
                        });
                    }
                });
            };
            MockModelService.prototype.getCellValue = function (coordinate) {
                return 1;
            };
            return MockModelService;
        })();
        model.MockModelService = MockModelService;
        var service = angular.module('exhibitGrid.modelService', []);
        service.factory('gridModelService', MockModelService);
    })(model = app.model || (app.model = {}));
})(app || (app = {}));
//# sourceMappingURL=modelService.js.map