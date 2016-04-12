/// <reference path="../typings/lodash/lodash.d.ts" />
var Service;
(function (Service) {
    var ExhibitVm = (function () {
        function ExhibitVm() {
            console.log("creating exhibitvm");
            this.Grids = new Array();
        }
        return ExhibitVm;
    }());
    Service.ExhibitVm = ExhibitVm;
    var GridVm = (function () {
        function GridVm(GridCode) {
            this.GridCode = GridCode;
        }
        return GridVm;
    }());
    Service.GridVm = GridVm;
    var RowVm = (function () {
        function RowVm(RowCode, Class, Text, CanCollapse, CanSelect, IsSelected) {
            this.RowCode = RowCode;
            this.Class = Class;
        }
        return RowVm;
    }());
    Service.RowVm = RowVm;
    var CellVm = (function () {
        function CellVm(Order, Type, RowCode, ColCode, CanAddNarrative, HasNarrative) {
            this.RowCode = RowCode;
            this.ColCode = ColCode;
        }
        return CellVm;
    }());
    Service.CellVm = CellVm;
    var CalcExpressionVm = (function () {
        function CalcExpressionVm() {
        }
        return CalcExpressionVm;
    }());
    Service.CalcExpressionVm = CalcExpressionVm;
    var CalcOperandVm = (function () {
        function CalcOperandVm() {
        }
        return CalcOperandVm;
    }());
    Service.CalcOperandVm = CalcOperandVm;
    var GridModelService = (function () {
        function GridModelService() {
            console.log("creating service");
            this.exhibitModel = new ExhibitVm();
        }
        GridModelService.prototype.addGridVm = function (gridVm) {
            this.exhibitModel.Grids.push(gridVm);
        };
        GridModelService.prototype.getExhibitVm = function () {
            return this.exhibitModel;
        };
        GridModelService.prototype.getGridVm = function (gridCode) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            return grid;
        };
        GridModelService.prototype.getRowVm = function (gridCode, rowCode) {
            console.log(gridCode);
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.Rows, { 'RowCode': rowCode });
            return row;
        };
        GridModelService.prototype.getCellVm = function (gridCode, rowCode, colCode) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.Rows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell;
        };
        GridModelService.prototype.updateCellValue = function (gridCode, rowCode, colCode, value) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.Rows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            cell.NumValue = value;
        };
        GridModelService.prototype.getCellValue = function (gridCode, rowCode, colCode) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.Rows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell.NumValue;
        };
        GridModelService.prototype.collapseChildren = function (gridCode, rowCode) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            _.each(_.where(grid.Rows, { 'ParentRowCode': rowCode }), function (child) {
                child.IsCollapsed = !child.IsCollapsed;
            });
        };
        GridModelService.prototype.getParentRowCalcForColumn = function (gridCode, parentRowCode, colCode) {
            var calc = "";
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            _.each(_.where(grid.Rows, { 'ParentRowCode': parentRowCode }), function (child) {
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
        return GridModelService;
    }());
    Service.GridModelService = GridModelService;
})(Service || (Service = {}));
//# sourceMappingURL=grid-model.service.js.map