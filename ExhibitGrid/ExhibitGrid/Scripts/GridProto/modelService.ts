/// <reference path="../typings/lodash/lodash.d.ts" />

'use strict';

module app.model {

    export interface IModelService {
        exhibitModel: ExhibitVm
        getExhibitModel(): ExhibitVm,
        getGridModel(gridCode: string): GridVm,
        getChildRows(gridCode: string, rowCode: string, pluckProp: string): {}[],
        addAnotherRow(gridCode: string): void,
        addAnotherColumn(gridCode: string): void,
        getCellValue(coordinate: string): number

    }

    export class ExhibitVm {
        ExhibitCode: string;
        Grids: GridVm[];

        constructor(ExhibitCode: string) {
            this.ExhibitCode = ExhibitCode;
            this.Grids = new Array<GridVm>();
        }

        addGrid(grid: GridVm) {
            this.Grids.push(grid);
        }
    }

    export class GridVm {
        GridCode: string;
        HasCreateDeleteColumn: boolean;
        HasSelectColumn: boolean;
        HasPostItColumn: boolean;
        HasNarrativeColumn: boolean;
        Rows: RowVm[];

        constructor(GridCode: string, HasCreateDeleteColumn: boolean, HasSelectColumn: boolean, HasPostItColumn: boolean, HasNarrativeColumn: boolean) {
            this.GridCode = GridCode;
            this.HasCreateDeleteColumn = HasCreateDeleteColumn;
            this.HasSelectColumn = HasSelectColumn;
            this.HasPostItColumn = HasPostItColumn;
            this.HasNarrativeColumn = HasNarrativeColumn;
        }
    }

    export class RowVm {
        RowCode: string;
        ParentRowCodes: string[];
        Type: RowType;
        Text: string;
        CreateDeleteFunction: RowFunction;
        CanSelect: boolean;
        AllowNarrative: boolean;
        AllowPostIt: boolean;
        Cells: CellVm[];
        constructor(RowCode: string, ParentRowCodes: string[], Type: RowType, Text: string, CreateDeleteFunction: RowFunction, CanSelect: boolean, AllowNarrative: boolean, AllowPostIt: boolean) {
            this.RowCode = RowCode;
            this.ParentRowCodes = ParentRowCodes;
            this.Type = Type;
            this.Text = Text;
            this.CreateDeleteFunction = CreateDeleteFunction;
            this.CanSelect = CanSelect;
            this.AllowNarrative = AllowNarrative;
            this.AllowPostIt = AllowPostIt;
        }
    }

    export enum RowType {
        Data, Total, Header
    }

    export enum RowFunction {
        Create, Delete, None
    }

    export class CellVm {
        ColCode: string;
        RowCode: string;
        Class: string;
        Type: CellType;
        Value: any;
        Width: string;
        IsEditable: boolean;

        constructor(ColCode: string, RowCode: string, Class: string, Type: CellType, Value: any, Width: string, IsEditable: boolean) {
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

    export enum CellType {
        NumericInput = 0, TextInput = 1, ReadOnly = 2
    }

    export class MockModelService implements IModelService {
        exhibitModel: ExhibitVm;

        constructor() {
            this.exhibitModel = new ExhibitVm("Test Exhibit");
            
            var grid = new GridVm('Grid_A', true, true, true, true);

            var headerRow: RowVm = new RowVm('Row_0', null, RowType.Header, 'Header Text', RowFunction.None, false, false, false);
            headerRow.Cells = [
                new CellVm('Col_Txt', 'Row_0', 'blank-cell', CellType.ReadOnly, null, '2x', false),
                new CellVm('Col_A', 'Row_0', 'header-cell', CellType.ReadOnly, 'Column A', '1x', false),
                new CellVm('Col_B', 'Row_0', 'header-cell', CellType.ReadOnly, 'Column B', '1x', false),
                new CellVm('Col_C', 'Row_0', 'header-cell', CellType.ReadOnly, 'Column C', '1x', false)
            ]

            var dataRow0: RowVm = new RowVm('Row_1', null, RowType.Data, 'Row Text', RowFunction.None, false, false, false);
            dataRow0.Cells = [
                new CellVm('Col_Txt', 'Row_1', 'text-cell', CellType.ReadOnly, null, '2x', false),
                new CellVm('Col_A', 'Row_1', 'data-cell', CellType.NumericInput, 50, '1x', false),
                new CellVm('Col_B', 'Row_1', 'data-cell', CellType.NumericInput, 100, '1x', false),
                new CellVm('Col_C', 'Row_1', 'data-cell', CellType.NumericInput, 150, '1x', false)
            ]

            grid.Rows = [headerRow, dataRow0];

            this.exhibitModel.addGrid(grid);
        }

        getExhibitModel() {
            return this.exhibitModel;
        }

        getGridModel(gridCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': [gridCode] })[0];
            return grid;
        }

        getChildRows(gridCode: string, rowCode: string, pluckProp: string) {
            var rows = _.where(this.exhibitModel[gridCode].Rows, { 'RowParents': [rowCode] });
            if (pluckProp) {
                rows = _.pluck(rows, pluckProp);
            }
            return rows;
        }

        addAnotherRow(gridCode: string) {
            var rowNum = this.exhibitModel[gridCode].Rows.length;
            var cells = [];
            _.forEach(this.exhibitModel[gridCode].Rows[0].Cells, function (va, idx: number) {
                if (idx === 0) {
                    cells.push({
                        ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'Row ' + rowNum, CellWidth: '2x'
                    });
                } else {
                    cells.push({
                        ColCode: 'Col_' + String.fromCharCode(idx + 64), CellClass: 'data-cell', CellType: 'num', CellValue: 500, CellWidth: '1x'
                    });
                }
            })

            this.exhibitModel[gridCode].Rows.push({
                RowCode: 'Row_' + rowNum, RowParents: null, RowClass: 'data-row', Cells: cells, RowText: 'Row ' + rowNum + ' Text'
            });
        }

        addAnotherColumn(gridCode: string) {
            var colLetter = String.fromCharCode(this.exhibitModel[gridCode].Rows[0].Cells.length + 64);

            _.forEach(this.exhibitModel[gridCode].Rows, function (val, idx: number) {
                if (idx == 0) {
                    val.Cells.push({
                        ColCode: 'Col_' + colLetter, CellClass: 'header-cell', CellType: 'text', CellValue: 'Column ' + colLetter, CellWidth: '1x', IsEditable: false
                    })
                } else {
                    val.Cells.push({
                        ColCode: 'Col_' + colLetter, CellClass: 'data-cell', CellType: 'num', CellValue: 800, CellWidth: '1x', IsEditable: true
                    })
                }
            })
        }

        getCellValue(coordinate: string) {
            return 1;
        }

    }

    var service = angular.module('app.model', []);

    service.factory('modelService', function () {
        return new MockModelService();
    });

}


