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
                this.Text = Text;
            }
            return RowVm;
        })();
        model.RowVm = RowVm;
        var CellVm = (function () {
            function CellVm(Order, Type, RowCode, ColCode, CanAddNarrative, HasNarrative) {
                this.Order = Order;
                this.Type = Type;
                this.RowCode = RowCode;
                this.ColCode = ColCode;
                this.CanAddNarrative = CanAddNarrative;
                this.HasNarrative = HasNarrative;
            }
            return CellVm;
        })();
        model.CellVm = CellVm;
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
                cell.Value = value;
            };
            MockModelService.prototype.getCellValue = function (gridCode, rowCode, colCode) {
                var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
                var row = _.find(grid.DataRows, { 'RowCode': rowCode });
                var cell = _.find(row.Cells, { 'ColCode': colCode });
                return cell.Value;
            };
            return MockModelService;
        })();
        model.MockModelService = MockModelService;
        var service = angular
            .module('app.model', [])
            .service('modelService', MockModelService);
    })(model = app.model || (app.model = {}));
})(app || (app = {}));
