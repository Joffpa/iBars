
 
 
 


 



/// <reference path="Enums.ts" />

declare module ExhibitGrid.ViewModel {
	interface IGridVm {
		GridCode: string;
		Rows: ExhibitGrid.ViewModel.IRowVm[];
	}
	interface IRowVm {
		RowCode: string;
		ParentRowCodes: string[];
		Class: string;
		Text: string;
		PeCode: string;
		SelectionCell: ExhibitGrid.ViewModel.ISelectionCellVm;
		CrudCell: ExhibitGrid.ViewModel.ICrudCellVm;
		NarrativeCell: ExhibitGrid.ViewModel.INarrativeCellVm;
		PostItCell: ExhibitGrid.ViewModel.IPostItCellVm;
		DataCells: ExhibitGrid.ViewModel.IDataCellVm[];
	}
	interface ISelectionCellVm {
		IncludeSpaceForCell: boolean;
		AllowSelect: boolean;
		IsSelected: boolean;
	}
	interface ICrudCellVm {
		IncludeSpaceForCell: boolean;
		CrudFunctionality: string;
	}
	interface INarrativeCellVm {
		IncludeSpaceForCell: boolean;
		AllowNarrative: boolean;
		HasNarrative: boolean;
	}
	interface IPostItCellVm {
		IncludeSpaceForCell: boolean;
		AllowPostIt: boolean;
		HasPostIt: boolean;
	}
	interface IDataCellVm {
		RowCode: string;
		ColCode: string;
		Class: string;
		Type: string;
		Width: string;
		IsEditable: boolean;
		Value: any;
	}
}
declare module ExhibitGrid.ViewModel.v2 {
	interface IGridVm {
		GridCode: string;
		Rows: ExhibitGrid.ViewModel.v2.IRowVm[];
	}
	interface IRowVm {
		RowCode: string;
		Class: string;
		Text: string;
		IncludeSpaceForCollapseIcon: boolean;
		CanCollapse: boolean;
		IncludeSpaceForSelectIcon: boolean;
		CanSelect: boolean;
		IsSelected: boolean;
		IncludeSpaceForCrudIcon: boolean;
		CrudIcon: string;
		Cells: ExhibitGrid.ViewModel.v2.IBaseCellVm[];
	}
	interface IBaseCellVm {
		Order: number;
		Type: string;
		RowCode: string;
		ColCode: string;
	}
}


