/// <reference path="../typings/lodash/lodash.d.ts" />

'use strict';

module app.v2.model {

    export interface IModelService {
        exhibitModel: ExhibitVm
        addGridVm(gridVm: ExhibitGrid.ViewModel.v2.IGridVm);
        getExhibitVm(): ExhibitVm,
        getGridVm(gridCode: string): ExhibitGrid.ViewModel.v2.IGridVm;
        getRowVm(gridCode: string, rowCode: string): ExhibitGrid.ViewModel.v2.IRowVm;
        getCellVm(gridCode: string, rowCode: string, colCode: string): ExhibitGrid.ViewModel.v2.ICellVm;
        getCellValue(gridCode: string, rowCode: string, colCode: string): number;
        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number): void;
    }

    export class ExhibitVm {
        ExhibitCode: string;
        Grids: ExhibitGrid.ViewModel.v2.IGridVm[];

        constructor(ExhibitCode: string) {
            this.ExhibitCode = ExhibitCode;
            this.Grids = new Array<ExhibitGrid.ViewModel.v2.IGridVm>();
        }        
    }

    export class GridVm implements ExhibitGrid.ViewModel.v2.IGridVm {

        GridCode: string;
        DataRows: ExhibitGrid.ViewModel.v2.IRowVm[];
        HasCollapseColumn: boolean;
        HasSelectColumn: boolean;
        HasAddColumn: boolean;
        HasDeleteColumn: boolean;
        NumColumns: number;
        ColumnHeaders: ExhibitGrid.ViewModel.v2.IColumnHeaderVm[];
        constructor(GridCode: string) {
            this.GridCode = GridCode;
        }
    }

    export class RowVm implements ExhibitGrid.ViewModel.v2.IRowVm {
        RowCode: string;
        Class: string;
        Text: string;
        CanCollapse: boolean;
        CanSelect: boolean;
        CanAdd: boolean;
        CanDelete: boolean;
        IsSelected: boolean;
        CrudFunctionality: string;
        IsHidden: boolean;
        Cells: ExhibitGrid.ViewModel.v2.ICellVm[];
        constructor(RowCode: string, Class: string, Text: string, CanCollapse: boolean, CanSelect: boolean, IsSelected: boolean) {
            this.RowCode = RowCode;
            this.Class = Class;
            this.Text = Text;
        }

    }

    export class CellVm implements ExhibitGrid.ViewModel.v2.ICellVm {
        Order: number;
        Type: string;
        RowCode: string;
        ColCode: string;
        CanAddNarrative: boolean;
        HasNarrative: boolean;
        HasPostIt: boolean;
        IsEditable: boolean;
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

        addGridVm(gridVm: ExhibitGrid.ViewModel.v2.IGridVm) {
            this.exhibitModel.Grids.push(gridVm);
        }

        getExhibitVm() {
            return this.exhibitModel;
        }

        getGridVm(gridCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            return grid;
        }

        getRowVm(gridCode: string, rowCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            var row = _.where(grid.DataRows, { 'RowCode': rowCode })[0];
            return row;
        }
        
        getCellVm(gridCode: string, rowCode: string, colCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            var row = _.where(grid.DataRows, { 'RowCode': rowCode })[0];
            var cell = _.where(row.Cells, { 'ColCode': colCode })[0];
            return cell;
        }

        updateCellValue(gridCode: string, rowCode: string, colCode: string, value: number) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            var row = _.where(grid.DataRows, { 'RowCode': rowCode })[0];
            var cell = _.where(row.Cells, { 'ColCode': colCode })[0];
            cell.Value = value;
        }

        getCellValue(gridCode: string, rowCode: string, colCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            var row = _.where(grid.DataRows, { 'RowCode': rowCode })[0];
            var cell = _.where(row.Cells, { 'ColCode': colCode })[0];
            return cell.Value;
        }

        //hack to simulate total row calc 
        sumAllCellsInColForTotalRow(gridCode: string, rowCode: string, colCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            var sum = 0;
            _.forEach(grid.DataRows, function (row) {
                if (row.RowCode != rowCode) {
                    var cell = _.where(row.Cells, { 'ColCode': colCode })[0];
                    sum += cell.Value;
                }
            });
            return sum;
        }

        constructor() {
            this.exhibitModel = new ExhibitVm("Test Exhibit");
            this.addGridVm(window['gridModel'].grid);
        }
    }

    var service = angular
        .module('app.v2.model', [])
        .service('modelService',  MockModelService);
}


