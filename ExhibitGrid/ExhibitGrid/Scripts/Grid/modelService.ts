/// <reference path="../typings/lodash/lodash.d.ts" />

'use strict';

module app.model {

    export interface IModelService {
        exhibitModel: ExhibitVm
        addGridVm(gridVm: ExhibitGrid.ViewModel.IGridVm);
        getExhibitVm(): ExhibitVm,
        getGridVm(gridCode: string): ExhibitGrid.ViewModel.IGridVm;
        getRowVm(gridCode: string, rowCode: string): ExhibitGrid.ViewModel.IRowVm;
        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.ICellVm;
        getCellValue(gridCode: string, rowCode: string, colCode: string): number;
        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number): void;
    }

    export class ExhibitVm {
        ExhibitCode: string;
        Grids: ExhibitGrid.ViewModel.IGridVm[];

        constructor(ExhibitCode: string) {
            this.ExhibitCode = ExhibitCode;
            this.Grids = new Array<ExhibitGrid.ViewModel.IGridVm>();
        }        
    }

    export class GridVm implements ExhibitGrid.ViewModel.IGridVm {

        GridCode: string;
        GridName: string;
        DataRows: ExhibitGrid.ViewModel.IRowVm[];
        HasCollapseColumn: boolean;
        HasSelectColumn: boolean;
        HasAddColumn: boolean;
        HasDeleteColumn: boolean;
        NumColumns: number;
        ColumnHeaders: ExhibitGrid.ViewModel.IColumnHeaderVm[];
        constructor(GridCode: string) {
            this.GridCode = GridCode;
        }
    }

    export class RowVm implements ExhibitGrid.ViewModel.IRowVm {
        RowCode: string;
        DisplayOrder: number;
        Class: string;
        Text: string;
        CanCollapse: boolean;
        CanSelect: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        IsSelected: boolean;
        CrudFunctionality: string;
        IsHidden: boolean;
        Cells: ExhibitGrid.ViewModel.ICellVm[];
        constructor(RowCode: string, Class: string, Text: string, CanCollapse: boolean, CanSelect: boolean, IsSelected: boolean) {
            this.RowCode = RowCode;
            this.Class = Class;
            this.Text = Text;
        }

    }

    export class CellVm implements ExhibitGrid.ViewModel.ICellVm {
        Order: number;
        Type: string;
        GridCode: string;
        RowCode: string;
        ColCode: string;
        ColSpan: number;
        ColumnHeader: string;
        CanAddNarrative: boolean;
        HasNarrative: boolean;
        HasPostIt: boolean;
        IsEditable: boolean;
        IsHidden: boolean;
        IsBlank: boolean;
        Directive: string;
        Text: string;
        Indent: number;
        Class: string;
        Value: number;
        constructor(Order: number, Type: string, RowCode: string, ColCode: string, CanAddNarrative: boolean, HasNarrative: boolean) {
            this.Order = Order;
            this.Type = Type;
            this.RowCode = RowCode;
            this.ColCode = ColCode;
            this.CanAddNarrative = CanAddNarrative;
            this.HasNarrative = HasNarrative;
        }
    }

    export class MockModelService implements IModelService {
        exhibitModel: ExhibitVm;

        addGridVm(gridVm: ExhibitGrid.ViewModel.IGridVm) {
            this.exhibitModel.Grids.push(gridVm);
        }

        getExhibitVm() {
            return this.exhibitModel;
        }

        getGridVm(gridCode: string) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            return grid;
        }

        getRowVm(gridCode: string, rowCode: string) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            return row;
        }
        
        getCellVm(gridCode: string, rowCode: string, colCode: string) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell;
        }

        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            cell.Value = value;
        }

        getCellValue(gridCode: string, rowCode: string, colCode: string) {
            var grid = _.find(this.exhibitModel.Grids, { 'GridCode': gridCode });
            var row = _.find(grid.DataRows, { 'RowCode': rowCode });
            var cell = _.find(row.Cells, { 'ColCode': colCode });
            return cell.Value;
        }
        
        constructor() {
            this.exhibitModel = new ExhibitVm("Test Exhibit");
            this.addGridVm(window['gridModel'].grid);
        }
    }

    var service = angular
        .module('app.model', [])
        .service('modelService',  MockModelService);
}


