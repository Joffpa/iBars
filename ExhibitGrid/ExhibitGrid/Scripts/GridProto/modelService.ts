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
        Rows: RowVm[];
        constructor(GridCode: string) {
            this.GridCode = GridCode;
        }
    }

    export class RowVm {
        RowCode: string;
        ParentRowCodes: string[];
        Type: RowType;
        Text: string;
        SelectionCell: SelectionCellVm;
        CrudCell: CrudCellVm;
        NarrativeCell: NarrativeCellVm;
        PostItCell: PostItCellVm;
        DataCells: DataCellVm[];
        constructor(RowCode: string, ParentRowCodes: string[], Type: RowType, Text: string) {
            this.RowCode = RowCode;
            this.ParentRowCodes = ParentRowCodes;
            this.Type = Type;
            this.Text = Text;
        }

    }
    
    export class SelectionCellVm {
        IncludeSpaceForCell: boolean;
        AllowSelect: boolean;
        IsSelected: boolean;
        constructor(IncludeSpaceForCell: boolean, AllowSelect: boolean, IsSelected: boolean) {
            this.IncludeSpaceForCell = IncludeSpaceForCell;
            this.AllowSelect = AllowSelect;
            this.IsSelected = IsSelected;
        }
    }

    export class CrudCellVm {
        IncludeSpaceForCell: boolean;
        CrudFunctionality: string;
        constructor(IncludeSpaceForCell: boolean, CrudFunctionality: string) {
            this.IncludeSpaceForCell = IncludeSpaceForCell;
            this.CrudFunctionality = CrudFunctionality;
        }
    }

    export class NarrativeCellVm {
        IncludeSpaceForCell: boolean;
        AllowNarrative: boolean;
        HasNarrative: boolean;
        constructor(IncludeSpaceForCell: boolean, AllowNarrative: boolean, HasNarrative: boolean) {
            this.IncludeSpaceForCell = IncludeSpaceForCell;
            this.AllowNarrative = AllowNarrative;
            this.HasNarrative = HasNarrative;
        }   
    }

    export class PostItCellVm {
        IncludeSpaceForCell: boolean;
        AllowPostIt: boolean;
        HasPostIt: boolean;
        constructor(IncludeSpaceForCell: boolean, AllowPostIt: boolean, HasPostIt: boolean) {
            this.IncludeSpaceForCell = IncludeSpaceForCell;
            this.AllowPostIt = AllowPostIt;
            this.HasPostIt = HasPostIt;
        }      
    }
    
    export enum RowType {
        Data, Total, Header
    }
    

    export class DataCellVm {
        ColCode: string;
        RowCode: string;
        Class: string;
        Type: string;
        Value: any;
        Width: string;
        IsEditable: boolean;

        constructor(ColCode: string, RowCode: string, Class: string, Type: string, Value: any, Width: string, IsEditable: boolean) {
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
            
            var grid = new GridVm('Grid_A');

            var headerRow: RowVm = new RowVm('Row_0', null, RowType.Header, 'Header Text');
            headerRow.SelectionCell = new SelectionCellVm(true, false, false);
            headerRow.CrudCell = new CrudCellVm(true, 'no-crud');
            headerRow.NarrativeCell = new NarrativeCellVm(true, false, false);
            headerRow.PostItCell = new PostItCellVm(true, false, false);
            headerRow.DataCells = [
                new DataCellVm('Col_Txt', 'Row_0', 'blank-cell', 'read-only', null, '1x', false),
                new DataCellVm('Col_A', 'Row_0', 'header-cell', 'read-only', 'Column A', '1x', false),
                new DataCellVm('Col_B', 'Row_0', 'header-cell', 'read-only', 'Column B', '1x', false),
                new DataCellVm('Col_C', 'Row_0', 'header-cell', 'read-only', 'Column C', '1x', false)
            ]

            var dataRow0: RowVm = new RowVm('Row_1', null, RowType.Data, 'Row Text');
            dataRow0.SelectionCell = new SelectionCellVm(true, true, false);
            dataRow0.CrudCell = new CrudCellVm(true, 'create');
            dataRow0.NarrativeCell = new NarrativeCellVm(true, true, false);
            dataRow0.PostItCell = new PostItCellVm(true, true, false);
            dataRow0.DataCells = [
                new DataCellVm('Col_Txt', 'Row_1', 'text-cell', 'read-only', null, '1x', false),
                new DataCellVm('Col_A', 'Row_1', 'data-cell', 'num-input', 50, '1x', false),
                new DataCellVm('Col_B', 'Row_1', 'data-cell', 'num-input', 100, '1x', false),
                new DataCellVm('Col_C', 'Row_1', 'data-cell', 'num-input', 150, '1x', false)
            ]

            grid.Rows = [headerRow, dataRow0];

            this.exhibitModel.addGrid(grid);
        }
        
        getExhibitModel() {
            return this.exhibitModel;
        }

        getGridModel(gridCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            return grid;
        }

        AddSpaceForSelectColumn() {
            
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


