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
            ExhibitVm.prototype.addGrid = function (grid) {
                this.Grids.push(grid);
            };
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
            function RowVm(RowCode, ParentRowCodes, Type, Text, CanSelect, CrudFunction, AllowNarrative, AllowPostIt) {
                this.RowCode = RowCode;
                this.ParentRowCodes = ParentRowCodes;
                this.Type = Type;
                this.Text = Text;
                this.CanSelect = CanSelect;
                this.CrudFunctionality = CrudFunction;
                this.AllowNarrative = AllowNarrative;
                this.AllowPostIt = AllowPostIt;
            }
            return RowVm;
        })();
        model.RowVm = RowVm;
        (function (RowType) {
            RowType[RowType["Data"] = 0] = "Data";
            RowType[RowType["Total"] = 1] = "Total";
            RowType[RowType["Header"] = 2] = "Header";
        })(model.RowType || (model.RowType = {}));
        var RowType = model.RowType;
        (function (RowCrud) {
            RowCrud[RowCrud["Create"] = 0] = "Create";
            RowCrud[RowCrud["Delete"] = 1] = "Delete";
            RowCrud[RowCrud["None"] = 2] = "None";
        })(model.RowCrud || (model.RowCrud = {}));
        var RowCrud = model.RowCrud;
        var CellVm = (function () {
            function CellVm(ColCode, RowCode, Class, Type, Value, Width, IsEditable) {
                this.ColCode = ColCode;
                this.RowCode = RowCode;
                this.Class = Class;
                this.Type = Type;
                this.Value = Value;
                this.Width = Width;
                this.IsEditable = IsEditable;
            }
            CellVm.prototype.getCoordinate = function () {
                return '{[' + this.RowCode + '][' + this.ColCode + ']}';
            };
            return CellVm;
        })();
        model.CellVm = CellVm;
        (function (CellType) {
            CellType[CellType["NumericInput"] = 0] = "NumericInput";
            CellType[CellType["TextInput"] = 1] = "TextInput";
            CellType[CellType["ReadOnly"] = 2] = "ReadOnly";
        })(model.CellType || (model.CellType = {}));
        var CellType = model.CellType;
        var MockModelService = (function () {
            function MockModelService() {
                this.exhibitModel = new ExhibitVm("Test Exhibit");
                var grid = new GridVm('Grid_A');
                var headerRow = new RowVm('Row_0', null, RowType.Header, 'Header Text', false, RowCrud.None, false, false);
                headerRow.Cells = [
                    new CellVm('Col_Txt', 'Row_0', 'blank-cell', CellType.ReadOnly, null, '2x', false),
                    new CellVm('Col_A', 'Row_0', 'header-cell', CellType.ReadOnly, 'Column A', '1x', false),
                    new CellVm('Col_B', 'Row_0', 'header-cell', CellType.ReadOnly, 'Column B', '1x', false),
                    new CellVm('Col_C', 'Row_0', 'header-cell', CellType.ReadOnly, 'Column C', '1x', false)
                ];
                var dataRow0 = new RowVm('Row_1', null, RowType.Data, 'Row Text', false, RowCrud.None, false, false);
                dataRow0.Cells = [
                    new CellVm('Col_Txt', 'Row_1', 'text-cell', CellType.ReadOnly, null, '2x', false),
                    new CellVm('Col_A', 'Row_1', 'data-cell', CellType.NumericInput, 50, '1x', false),
                    new CellVm('Col_B', 'Row_1', 'data-cell', CellType.NumericInput, 100, '1x', false),
                    new CellVm('Col_C', 'Row_1', 'data-cell', CellType.NumericInput, 150, '1x', false)
                ];
                grid.Rows = [headerRow, dataRow0];
                this.exhibitModel.addGrid(grid);
            }
            MockModelService.prototype.initModel = function () {
                var hasSelectColumn = false;
                _.forEach(this.exhibitModel.Grids, function (eVal, eIdx) {
                    _.forEach(eVal.Rows, function (val, idx, coll) {
                        if (val.CrudFunctionality != RowCrud.None) {
                            hasSelectColumn = true;
                            return false;
                        }
                    });
                });
            };
            MockModelService.prototype.getExhibitModel = function () {
                return this.exhibitModel;
            };
            MockModelService.prototype.getGridModel = function (gridCode) {
                var grid = _.where(this.exhibitModel.Grids, { 'GridCode': [gridCode] })[0];
                return grid;
            };
            MockModelService.prototype.AddSpaceForSelectColumn = function () {
            };
            MockModelService.prototype.getChildRows = function (gridCode, rowCode, pluckProp) {
                var rows = _.where(this.exhibitModel[gridCode].Rows, { 'RowParents': [rowCode] });
                if (pluckProp) {
                    rows = _.pluck(rows, pluckProp);
                }
                return rows;
            };
            MockModelService.prototype.addAnotherRow = function (gridCode) {
                var rowNum = this.exhibitModel[gridCode].Rows.length;
                var cells = [];
                _.forEach(this.exhibitModel[gridCode].Rows[0].Cells, function (va, idx) {
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
                this.exhibitModel[gridCode].Rows.push({
                    RowCode: 'Row_' + rowNum, RowParents: null, RowClass: 'data-row', Cells: cells, RowText: 'Row ' + rowNum + ' Text'
                });
            };
            MockModelService.prototype.addAnotherColumn = function (gridCode) {
                var colLetter = String.fromCharCode(this.exhibitModel[gridCode].Rows[0].Cells.length + 64);
                _.forEach(this.exhibitModel[gridCode].Rows, function (val, idx) {
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
        var service = angular.module('app.model', []);
        service.factory('modelService', function () {
            return new MockModelService();
        });
    })(model = app.model || (app.model = {}));
})(app || (app = {}));
