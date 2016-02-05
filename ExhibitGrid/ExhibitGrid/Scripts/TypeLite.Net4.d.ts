
 
 
 


 



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
	interface IBaseCellVm {
		Order: number;
		Type: string;
		RowCode: string;
		ColCode: string;
	}
	interface IDataCellVm extends ExhibitGrid.ViewModel.v2.IBaseCellVm {
		Class: string;
		Width: string;
		IsEditable: boolean;
		Value: any;
	}
	interface IGridVm {
		GridCode: string;
		DataRows: ExhibitGrid.ViewModel.v2.IRowVm[];
	}
	interface IRowVm {
		RowCode: string;
		Class: string;
		Text: string;
		CanCollapse: boolean;
		CanSelect: boolean;
		IsSelected: boolean;
		Cells: ExhibitGrid.ViewModel.v2.IBaseCellVm[];
	}
	interface INarrativeCellVm extends ExhibitGrid.ViewModel.v2.IBaseCellVm {
		CanAddNarrative: boolean;
		HasNarrative: boolean;
	}
	interface IPostItCellVm extends ExhibitGrid.ViewModel.v2.IBaseCellVm {
		CanHavePostIt: boolean;
		HasPostIt: boolean;
	}
	interface IRowTextCellVm extends ExhibitGrid.ViewModel.v2.IBaseCellVm {
		Text: string;
		IsEditable: boolean;
	}
}


