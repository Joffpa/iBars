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
        var GeneratedRowVm = (function () {
            function GeneratedRowVm() {
            }
            return GeneratedRowVm;
        })();
        model.GeneratedRowVm = GeneratedRowVm;
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
                var numRows = 16;
                var numColumns = 17;
                var grid = new GridVm('Grid_A');
                var headerRow = new RowVm('Row_0', null, RowType.Header, 'Header Text');
                headerRow.SelectionCell = new SelectionCellVm(true, false, false);
                headerRow.CrudCell = new CrudCellVm(true, 'no-crud');
                headerRow.NarrativeCell = new NarrativeCellVm(true, false, false);
                headerRow.PostItCell = new PostItCellVm(true, false, false);
                headerRow.DataCells = [new DataCellVm('Col_Txt', 'Row_0', 'blank-cell', 'read-only', null, '1x', false)];
                for (var c = 0; c <= numColumns; c++) {
                    var cell = new DataCellVm('Col_' + c, 'Row_0', 'header-cell', 'read-only', 'Column ' + c, '1x', false);
                    headerRow.DataCells.push(cell);
                }
                grid.Rows = [headerRow];
                for (var r = 1; r <= numRows; r++) {
                    var dataRow0 = new RowVm('Row_' + r, null, RowType.Data, 'Row Text');
                    dataRow0.SelectionCell = new SelectionCellVm(true, true, false);
                    dataRow0.CrudCell = new CrudCellVm(true, 'create');
                    dataRow0.NarrativeCell = new NarrativeCellVm(true, true, false);
                    dataRow0.PostItCell = new PostItCellVm(true, true, false);
                    dataRow0.DataCells = [new DataCellVm('Col_Txt', 'Row_' + r, 'text-cell', 'read-only', null, '1x', false)];
                    for (var c = 0; c <= numColumns; c++) {
                        var cell = new DataCellVm('Col_' + c, 'Row_' + r, 'data-cell', 'num-input', 150, '1x', false);
                        dataRow0.DataCells.push(cell);
                    }
                    grid.Rows.push(dataRow0);
                }
                console.log(grid);
                this.exhibitModel.addGrid(grid);
            }
            MockModelService.prototype.getExhibitModel = function () {
                return this.exhibitModel;
            };
            MockModelService.prototype.getGridModel = function (gridCode) {
                var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
                return grid;
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