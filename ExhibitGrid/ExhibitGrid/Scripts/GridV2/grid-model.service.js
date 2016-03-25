var Services;
(function (Services) {
    var GridModelService = (function () {
        function GridModelService() {
            this.exhibitModel = new app.model.ExhibitVm();
            this.addGridVm(window['easGrid'].gridVm);
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
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            return row;
        };
        GridModelService.prototype.getCellVm = function (gridCode, rowCode, colCode) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell;
        };
        GridModelService.prototype.updateCellValue = function (gridCode, rowCode, colCode, value) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            cell.NumValue = value;
        };
        GridModelService.prototype.getCellValue = function (gridCode, rowCode, colCode) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell.NumValue;
        };
        GridModelService.prototype.collapseChildren = function (gridCode, rowCode) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            _.each(_.where(grid.DataRows, { 'ParentRowCode': rowCode }), function (child) {
                child.IsCollapsed = !child.IsCollapsed;
            });
        };
        GridModelService.prototype.getParentRowCalcForColumn = function (gridCode, parentRowCode, colCode) {
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
        return GridModelService;
    }());
    Services.GridModelService = GridModelService;
})(Services || (Services = {}));
//# sourceMappingURL=grid-model.service.js.map