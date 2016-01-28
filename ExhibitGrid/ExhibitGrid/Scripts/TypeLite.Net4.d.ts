
 
 
 


 



/// <reference path="Enums.ts" />

declare module ExhibitGrid.ViewModel {
	interface GridVm {
		GridCode: string;
		GridAttrib1: string;
		GridAttrib2: string;
		GridAttrib3: string;
		GridAttrib4: string;
		Rows: ExhibitGrid.ViewModel.RowVm[];
	}
	interface RowVm {
		RowCode: string;
		RowAttrib1: string;
		RowAttrib2: string;
		RowAttrib3: string;
		RowAttrib4: string;
		RowAttrib5: string;
		RowAttrib6: string;
		RowAttrib7: boolean;
		RowAttrib8: boolean;
		RowAttrib9: boolean;
		RowAttrib10: boolean;
		RowAttrib11: boolean;
		RowAttrib12: boolean;
		Cells: ExhibitGrid.ViewModel.CellVm[];
	}
	interface CellVm {
		RowCode: string;
		ColCode: string;
		CellAttrib1: string;
		CellAttrib2: string;
		CellAttrib3: string;
		CellAttrib4: string;
		CellAttrib5: string;
		CellAttrib6: string;
		CellAttrib7: boolean;
		CellAttrib8: boolean;
		CellAttrib9: boolean;
		CellAttrib10: boolean;
		CellAttrib11: boolean;
		CellAttrib12: boolean;
	}
}


