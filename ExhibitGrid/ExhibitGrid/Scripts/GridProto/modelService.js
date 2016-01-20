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
            function RowVm(RowCode, ParentRowCodes, Type, Text) {
                this.RowCode = RowCode;
                this.ParentRowCodes = ParentRowCodes;
                this.Type = Type;
                this.Text = Text;
            }
            return RowVm;
        })();
        model.RowVm = RowVm;
        var SelectionCellVm = (function () {
            function SelectionCellVm(IncludeSpaceForCell, AllowSelect, IsSelected) {
                this.IncludeSpaceForCell = IncludeSpaceForCell;
                this.AllowSelect = AllowSelect;
                this.IsSelected = IsSelected;
            }
            return SelectionCellVm;
        })();
        model.SelectionCellVm = SelectionCellVm;
        var CrudCellVm = (function () {
            function CrudCellVm(IncludeSpaceForCell, CrudFunctionality) {
                this.IncludeSpaceForCell = IncludeSpaceForCell;
                this.CrudFunctionality = CrudFunctionality;
            }
            return CrudCellVm;
        })();
        model.CrudCellVm = CrudCellVm;
        var NarrativeCellVm = (function () {
            function NarrativeCellVm(IncludeSpaceForCell, AllowNarrative, HasNarrative) {
                this.IncludeSpaceForCell = IncludeSpaceForCell;
                this.AllowNarrative = AllowNarrative;
                this.HasNarrative = HasNarrative;
            }
            return NarrativeCellVm;
        })();
        model.NarrativeCellVm = NarrativeCellVm;
        var PostItCellVm = (function () {
            function PostItCellVm(IncludeSpaceForCell, AllowPostIt, HasPostIt) {
                this.IncludeSpaceForCell = IncludeSpaceForCell;
                this.AllowPostIt = AllowPostIt;
                this.HasPostIt = HasPostIt;
            }
            return PostItCellVm;
        })();
        model.PostItCellVm = PostItCellVm;
        (function (RowType) {
            RowType[RowType["Data"] = 0] = "Data";
            RowType[RowType["Total"] = 1] = "Total";
            RowType[RowType["Header"] = 2] = "Header";
        })(model.RowType || (model.RowType = {}));
        var RowType = model.RowType;
        var DataCellVm = (function () {
            function DataCellVm(ColCode, RowCode, Class, Type, Value, Width, IsEditable) {
                this.ColCode = ColCode;
                this.RowCode = RowCode;
                this.Class = Class;
                this.Type = Type;
                this.Value = Value;
                this.Width = Width;
                this.IsEditable = IsEditable;
            }
            DataCellVm.prototype.getCoordinate = function () {
                return '{[' + this.RowCode + '][' + this.ColCode + ']}';
            };
            return DataCellVm;
        })();
        model.DataCellVm = DataCellVm;
        var MockModelService = (function () {
            function MockModelService() {
                this.exhibitModel = new ExhibitVm("Test Exhibit");
                var grid = new GridVm('Grid_A');
                var headerRow = new RowVm('Row_0', null, RowType.Header, 'Header Text');
                headerRow.SelectionCell = new SelectionCellVm(true, false, false);
                headerRow.CrudCell = new CrudCellVm(true, 'no-crud');
                headerRow.NarrativeCell = new NarrativeCellVm(true, false, false);
                headerRow.PostItCell = new PostItCellVm(true, false, false);
                headerRow.DataCells = [
                    new DataCellVm('Col_Txt', 'Row_0', 'blank-cell', 'read-only', null, '1x', false),
                    new DataCellVm('Col_A', 'Row_0', 'header-cell', 'read-only', 'Column A', '1x', false),
                    new DataCellVm('Col_B', 'Row_0', 'header-cell', 'read-only', 'Column B', '1x', false),
                    new DataCellVm('Col_C', 'Row_0', 'header-cell', 'read-only', 'Column C', '1x', false)
                ];
                var dataRow0 = new RowVm('Row_1', null, RowType.Data, 'Row Text');
                dataRow0.SelectionCell = new SelectionCellVm(true, true, false);
                dataRow0.CrudCell = new CrudCellVm(true, 'create');
                dataRow0.NarrativeCell = new NarrativeCellVm(true, true, false);
                dataRow0.PostItCell = new PostItCellVm(true, true, false);
                dataRow0.DataCells = [
                    new DataCellVm('Col_Txt', 'Row_1', 'text-cell', 'read-only', null, '1x', false),
                    new DataCellVm('Col_A', 'Row_1', 'data-cell', 'num-input', 50, '1x', false),
                    new DataCellVm('Col_B', 'Row_1', 'data-cell', 'num-input', 100, '1x', false),
                    new DataCellVm('Col_C', 'Row_1', 'data-cell', 'num-input', 150, '1x', false)
                ];
                grid.Rows = [headerRow, dataRow0];
                this.exhibitModel.addGrid(grid);
            }
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
//# sourceMappingURL=modelService.js.map