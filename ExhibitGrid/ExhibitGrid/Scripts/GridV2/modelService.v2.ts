/// <reference path="../typings/lodash/lodash.d.ts" />

'use strict';

module app.v2.model {

    export interface IModelService {
        exhibitModel: ExhibitVm
        getExhibitVm(): ExhibitVm,
        getGridVm(gridCode: string): ExhibitGrid.ViewModel.v2.IGridVm;
        getRowVm(gridCode: string, rowCode: string): ExhibitGrid.ViewModel.v2.IRowVm;
    }

    export class ExhibitVm {
        ExhibitCode: string;
        Grids: ExhibitGrid.ViewModel.v2.IGridVm[];

        constructor(ExhibitCode: string) {
            this.ExhibitCode = ExhibitCode;
            this.Grids = new Array<ExhibitGrid.ViewModel.v2.IGridVm>();
        }

        addGrid(grid: ExhibitGrid.ViewModel.v2.IGridVm) {
            this.Grids.push(grid);
        }
    }

    export class GridVm implements ExhibitGrid.ViewModel.v2.IGridVm {

        GridCode: string;
        DataRows: ExhibitGrid.ViewModel.v2.IRowVm[];
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
        IsSelected: boolean;
        Cells: ExhibitGrid.ViewModel.v2.IBaseCellVm[];
        constructor(RowCode: string, Class: string, Text: string, CanCollapse: boolean, CanSelect: boolean, IsSelected: boolean) {
            this.RowCode = RowCode;
            this.Class = Class;
            this.Text = Text;
        }

    }

    export class NarrativeCellVm implements ExhibitGrid.ViewModel.v2.INarrativeCellVm {
        Order: number;
        Type: string;
        RowCode: string;
        ColCode: string;
        CanAddNarrative: boolean;
        HasNarrative: boolean;
        constructor(Order: number, Type: string, RowCode: string, ColCode: string, CanAddNarrative: boolean, HasNarrative: boolean) {
            this.Order = Order;
            this.Type = Type;
            this.RowCode = RowCode;
            this.ColCode = ColCode;
            this.CanAddNarrative = CanAddNarrative;
            this.HasNarrative = HasNarrative;
        }
    }

    export class PostItCellVm implements ExhibitGrid.ViewModel.v2.IPostItCellVm {
        Order: number;
        Type: string;
        RowCode: string;
        ColCode: string;
        CanHavePostIt: boolean;
        HasPostIt: boolean;
        constructor(Order: number, Type: string, RowCode: string, ColCode: string, CanHavePostIt: boolean, HasPostIt: boolean) {
            this.Order = Order;
            this.Type = Type;
            this.RowCode = RowCode;
            this.ColCode = ColCode;
            this.CanHavePostIt = CanHavePostIt;
            this.HasPostIt = HasPostIt;
        }
    }


    export class DataCellVm implements ExhibitGrid.ViewModel.v2.IDataCellVm {
        Order: number;
        ColCode: string;
        RowCode: string;
        Type: string;
        Class: string;
        Width: string;
        IsEditable: boolean;
        Value: any;

        constructor(Order: number, ColCode: string, RowCode: string, Class: string, Type: string, Value: any, Width: string, IsEditable: boolean) {
            this.Order = Order;
            this.ColCode = ColCode;
            this.RowCode = RowCode;
            this.Class = Class;
            this.Type = Type;
            this.Value = Value;
            this.Width = Width;
            this.IsEditable = IsEditable;
        }

        getCoordinate() {
            return '{[' + this.RowCode + '][' + this.ColCode + ']}';
        }
    }

    export class MockModelService implements IModelService {
        exhibitModel: ExhibitVm;

        constructor() {
            this.exhibitModel = new ExhibitVm("Test Exhibit");

            var numRows = 16;
            var numColumns = 10;
            
            var grid = window["gridModel"].currentGrid;

            //console.log(grid);

            //var grid = new GridVm('MockGrid');

            //var headerRow: RowVm = new RowVm('Row_0', null, 'header', 'Header Text');
            //headerRow.SelectionCell = new SelectionCellVm(true, false, false);
            //headerRow.CrudCell = new CrudCellVm(true, 'no-crud');
            //headerRow.NarrativeCell = new NarrativeCellVm(true, false, false);
            //headerRow.PostItCell = new PostItCellVm(true, false, false);
            //headerRow.DataCells = [new DataCellVm('Col_Txt', 'Row_0', 'blank-cell', 'read-only', null, '1x', false)];

            //for (var c = 0; c <= numColumns; c++) {
            //    var cell = new DataCellVm('Col_' + c, 'Row_0', 'header-cell', 'read-only', 'Column ' + c, '1x', false);
            //    headerRow.DataCells.push(cell);
            //}

            //grid.Rows = [headerRow];

            //for (var r = 1; r <= numRows; r++) {
            //    var dataRow0: RowVm = new RowVm('Row_' + r, null, 'data', 'Row Text');
            //    dataRow0.SelectionCell = new SelectionCellVm(true, true, false);
            //    dataRow0.CrudCell = new CrudCellVm(true, 'create');
            //    dataRow0.NarrativeCell = new NarrativeCellVm(true, true, false);
            //    dataRow0.PostItCell = new PostItCellVm(true, true, false);
            //    dataRow0.DataCells = [new DataCellVm('Col_Txt', 'Row_' + r, 'text-cell', 'read-only', null, '1x', false)];

            //    for (var c = 0; c <= numColumns; c++) {
            //        var cell = new DataCellVm('Col_' + c, 'Row_' + r, 'data-cell', 'num-input', 150, '1x', false);
            //        dataRow0.DataCells.push(cell);
            //    }
            //    grid.Rows.push(dataRow0);
            //}

            //console.log(grid);
            
            this.exhibitModel.addGrid(grid);
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

    }

    var service = angular
        .module('app.v2.model', [])
        .factory('modelService', function () {
            return new MockModelService();
        });
}


