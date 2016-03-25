module Services {
    export class GridModelService {

        exhibitModel: app.model.ExhibitVm;

        addGridVm(gridVm: ExhibitGrid.ViewModel.IGridVm) {
            this.exhibitModel.Grids.push(gridVm);
        }

        getExhibitVm() {
            return this.exhibitModel;
        }

        getGridVm(gridCode: string): ExhibitGrid.ViewModel.IGridVm {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            return grid;
        }

        getRowVm(gridCode: string, rowCode: string): ExhibitGrid.ViewModel.IRowVm {
            console.log(gridCode);
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            return row;
        }

        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell;
        }

        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            cell.NumValue = value;
        }

        getCellValue(gridCode: string, rowCode: string, colCode: string): number {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell.NumValue;
        }

        collapseChildren(gridCode: string, rowCode: string) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            _.each(_.where(grid.DataRows, { 'ParentRowCode': rowCode }), child => {
                child.IsCollapsed = !child.IsCollapsed;
            });

        }

        getParentRowCalcForColumn(gridCode: string, parentRowCode: string, colCode) {
            var calc = "";
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            _.each(_.where(grid.DataRows, { 'ParentRowCode': parentRowCode }), child => {
                var cell = _.find(child.Cells, { 'ColCode': colCode });
                calc += cell.NumValue.toString() + "+";
            });
            if (calc && calc.length > 2) {
                calc.substring(0, calc.length - 2);
            } else {
                calc = "0";
            }
            return calc;
        }

        constructor() {
            this.exhibitModel = new app.model.ExhibitVm();
            this.addGridVm(window['easGrid'].gridVm);
        }
    }
}