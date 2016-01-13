/// <reference path="../typings/lodash/lodash.d.ts" />

'use strict';

module app.model{

    export interface IModelService {
        viewModel: IGridVm[],
        getGridModel(gridCode: string): IGridVm,
        getChildRows(gridCode: string, rowCode: string, pluckProp: string): {}[],
        addAnotherRow(gridCode: string): void,
        addAnotherColumn(gridCode: string): void,
        getCellValue(coordinate: string): number

    }

    export interface IGridVm {        
        HasCreateDeleteColumn: boolean,
        HasSelectColumn: boolean,
        HasPostItColumn: boolean,
        HasNarrativeColumn: boolean,
        Rows: IRowVm[]

    }

    export interface IRowVm {
        RowCode: string,
        ParentRowCodes: string[],
        Type: RowType,
        Text: string,
        CreateDeleteFunction: RowFunction,
        CanSelect: boolean,
        HasNarrative: boolean,
        HasPostIt: boolean,
        Cells: ICellVm[]

    }
    
    export interface ICellVm {
        ColCode: string,
        RowCode: string,
        Class: string,
        Type: string,
        Value: any,
        Width: number,
        IsEditable: boolean,
        getCoordinate(): string,

    }

    export enum RowType {
        Data, Total, Header
    }

    export enum RowFunction{
        Create, Delete
    }

    export class GridVm implements IGridVm{
        HasCreateDeleteColumn: boolean;
        HasSelectColumn: boolean;
        HasPostItColumn: boolean;
        HasNarrativeColumn: boolean;
        Rows: IRowVm[];

        constructor() {

        }
    }

    export class RowVm implements IRowVm {
        RowCode: string;
        ParentRowCodes: string[];
        Type: RowType;
        Text: string;
        CreateDeleteFunction: RowFunction;
        CanSelect: boolean;
        HasNarrative: boolean;
        HasPostIt: boolean;
        Cells: ICellVm[];
        constructor() {

        }
    }

    export class CellVm implements ICellVm {
        ColCode: string;
        RowCode: string;
        Class: string;
        Type: string;
        Value: any;
        Width: number;
        IsEditable: boolean;

        getCoordinate() {
            return '{[' + this.RowCode + '][' + this.ColCode +']}';
        }
    }
    
    export class MockModelService implements IModelService {
        viewModel:  IGridVm[];

        constructor() {
            //this.viewModel =  {
            //    Rows: [
            //        {
            //            RowCode: 'Row_0', RowParents: null, RowClass: 'header-row', RowText: 'Header Text',
            //            Cells: [
            //                { ColCode: 'Col_Txt', CellClass: 'blank-cell', CellType: 'text', CellValue: null, CellWidth: '2x', IsEditable: false },
            //                { ColCode: 'Col_A', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column A', CellWidth: '1x', IsEditable: false },
            //                { ColCode: 'Col_B', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column B', CellWidth: '1x', IsEditable: false },
            //                { ColCode: 'Col_C', CellClass: 'header-cell', CellType: 'text', CellValue: 'Column C', CellWidth: '1x', IsEditable: false }
            //            ]
            //        },
            //        {
            //            RowCode: 'Row_1', RowParents: null, RowClass: 'total-row', RowText: 'Row 1 text',
            //            Cells: [
            //                { ColCode: 'Col_Txt', CellClass: 'text-cell', CellType: 'text', CellValue: 'text', CellWidth: '2x', IsEditable: false },
            //                { ColCode: 'Col_A', CellClass: 'data-cell', CellType: 'num', CellValue: 50, CellWidth: '1x', IsEditable: true },
            //                { ColCode: 'Col_B', CellClass: 'data-cell', CellType: 'num', CellValue: 100, CellWidth: '1x', IsEditable: true },
            //                { ColCode: 'Col_C', CellClass: 'data-cell', CellType: 'num', CellValue: 150, CellWidth: '1x', IsEditable: true }
            //            ]
            //        }
            //    ]
            //};
        }

        getGridModel(gridCode: string) {
            return this.viewModel[gridCode];
        }
        
        getChildRows(gridCode:string, rowCode: string, pluckProp: string) {
            var rows = _.where(this.viewModel[gridCode].Rows, { 'RowParents': [rowCode] });
            if (pluckProp) {
                rows = _.pluck(rows, pluckProp);
            }
            return rows;
        }

        addAnotherRow(gridCode: string) {
            var rowNum = this.viewModel[gridCode].Rows.length;
            var cells = [];
            _.forEach(this.viewModel[gridCode].Rows[0].Cells, function (va, idx: number) {
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

            this.viewModel[gridCode].Rows.push({
                RowCode: 'Row_' + rowNum, RowParents: null, RowClass: 'data-row', Cells: cells, RowText: 'Row ' + rowNum + ' Text'
            });
        }

        addAnotherColumn(gridCode: string) {
            var colLetter = String.fromCharCode(this.viewModel[gridCode].Rows[0].Cells.length + 64);

            _.forEach(this.viewModel[gridCode].Rows, function (val, idx: number) {
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


    var service = angular.module('exhibitGrid.modelService', []);

    service.factory('gridModelService', MockModelService);
}