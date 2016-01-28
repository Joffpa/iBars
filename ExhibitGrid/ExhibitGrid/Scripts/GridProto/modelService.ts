/// <reference path="../typings/lodash/lodash.d.ts" />

'use strict';

module app.model {

    export interface IModelService {
        exhibitModel: ExhibitVm
        getExhibitModel(): ExhibitVm,
        getGridModel(gridCode: string): GridVm
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

            var numRows = 16;
            var numColumns = 17;

            var grid = new GridVm('Grid_A');

            var headerRow: RowVm = new RowVm('Row_0', null, RowType.Header, 'Header Text');
            headerRow.SelectionCell = new SelectionCellVm(true, false, false);
            headerRow.CrudCell = new CrudCellVm(true, 'no-crud');
            headerRow.NarrativeCell = new NarrativeCellVm(true, false, false);
            headerRow.PostItCell = new PostItCellVm(true, false, false);
            headerRow.DataCells = [new DataCellVm('Col_Txt', 'Row_0', 'blank-cell', 'read-only', null, '1x', false)];

            for (var c = 0; c <= numColumns; c++) {
                var cell = new DataCellVm('Col_' + c, 'Row_0', 'header-cell', 'read-only', 'Column ' + c, '1x', false);
                headerRow.DataCells.push(cell); 
            }
            
            grid.Rows = [headerRow];

            for (var r = 1; r <= numRows; r++) {
                var dataRow0: RowVm = new RowVm('Row_' + r, null, RowType.Data, 'Row Text');
                dataRow0.SelectionCell = new SelectionCellVm(true, true, false);
                dataRow0.CrudCell = new CrudCellVm(true, 'create');
                dataRow0.NarrativeCell = new NarrativeCellVm(true, true, false);
                dataRow0.PostItCell = new PostItCellVm(true, true, false);
                dataRow0.DataCells = [new DataCellVm('Col_Txt', 'Row_' + r, 'text-cell', 'read-only', null, '1x', false)];

                for (var c = 0; c <= numColumns; c++) {
                    var cell = new DataCellVm('Col_' +c, 'Row_' + r, 'data-cell', 'num-input', 150, '1x', false);
                    dataRow0.DataCells.push(cell);
                }

                grid.Rows.push(dataRow0);

            }

            console.log(grid);
                                    

            this.exhibitModel.addGrid(grid);
        }
        
        
        getExhibitModel() {
            return this.exhibitModel;
        }

        getGridModel(gridCode: string) {
            var grid = _.where(this.exhibitModel.Grids, { 'GridCode': gridCode })[0];
            return grid;
        }
        
    }

    var service = angular.module('app.model', []);
    
    service.factory('modelService', function () {
        return new MockModelService();
    });

}


