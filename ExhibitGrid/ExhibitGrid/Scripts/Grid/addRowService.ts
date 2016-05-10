module app.addRow {

    export interface IAddRowService {

        addRowsFromRowTemplate(parentRowVm: ExhibitGrid.ViewModel.IRowVm): void;
        addRowsFromGridTemplate(gridCode: string): void;
        deleteRow(rowVm: ExhibitGrid.ViewModel.IRowVm): void;
    }

    export class AddRowService implements IAddRowService
    {
        ModelService: app.model.IModelService;
        CalcService: app.calc.ICalcService;

        constructor(modelService: app.model.IModelService, calcService: app.calc.ICalcService) {
            this.ModelService = modelService;
            this.CalcService = calcService;
        }

        addRowsFromRowTemplate(parentRowVm: ExhibitGrid.ViewModel.IRowVm) {
            if (parentRowVm.TemplateRows == null || parentRowVm.TemplateRows.length < 1) {
                return;
            }
            var grid = this.ModelService.getGridVm(parentRowVm.GridCode);

            //get template rows
            var templateRows = parentRowVm.TemplateRows;

            //Get ColCalcs
            var colCalcs = this.ModelService.getGridColCalcs(parentRowVm.GridCode);
            var preExistingChildRows = this.ModelService.getChildRowVms(parentRowVm);

            var nextRowNum = this.getNextChildRowNumber(preExistingChildRows);
            var displayOrder = this.getNextDisplayOrder(preExistingChildRows, parentRowVm.DisplayOrder);

            var newRows: ExhibitGrid.ViewModel.IRowVm[] = [];
            _.forEach(templateRows, templateRow => {
                //increment order
                displayOrder = displayOrder + .01;
                //increment rowNumber
                nextRowNum = nextRowNum + 1;
                //create new rowcode
                var newRowCode = parentRowVm.RowCode + "_child_" + nextRowNum.toString();
                var newRow = this.createRowFromTemplate(templateRow, displayOrder, newRowCode, colCalcs);
                if (templateRow.CollapseParentRowCode) {
                    var collapseParentVm;
                    if (templateRow.CollapseParentRowCode == parentRowVm.RowCode) {
                        collapseParentVm = parentRowVm;
                    } else {
                        collapseParentVm = this.ModelService.getRowVm(templateRow.GridCode, templateRow.CollapseParentRowCode)
                    }
                    collapseParentVm.CollapseableChildrenRowCodes.push(newRow.RowCode);
                }
                if (templateRow.TotalParentRowCode) {
                    var totalParentVm;
                    if (templateRow.TotalParentRowCode == parentRowVm.RowCode) {
                        totalParentVm = parentRowVm;
                    } else {
                        totalParentVm = this.ModelService.getRowVm(templateRow.GridCode, templateRow.TotalParentRowCode)
                    }
                    totalParentVm.TotalChildrenRowCodes.push(newRow.RowCode);
                }
                grid.Rows.push(newRow);
            });

            //uncollapse parent to show new children
            this.ModelService.collapseChildren(parentRowVm, false);
        }

        addRowsFromGridTemplate(gridCode: string) {

        }

        createRowFromTemplate(templateRow: ExhibitGrid.ViewModel.IRowVm, order: number, rowCode: string, colCalcs: ExhibitGrid.ViewModel.ICalcExpressionVm[]) {
            var newRow: ExhibitGrid.ViewModel.IRowVm = {
                GridCode:                       templateRow.GridCode,
                RowCode:                        rowCode,
                DisplayOrder:                   order,
                Class:                          templateRow.Class,
                CanCollapse:                    templateRow.CanCollapse,
                CanAdd:                         templateRow.CanAdd,
                CanDelete:                      templateRow.CanDelete,
                CanSelect:                      templateRow.CanSelect,
                IsHidden:                       templateRow.IsHidden,
                IsCollapsed:                    false,
                ChildrenAreCollapsed:           false,
                IsSelected:                     templateRow.IsSelected,
                IsEditable:                     templateRow.IsEditable,
                Type:                           templateRow.Type,
                CollapseParentRowCode:          templateRow.CollapseParentRowCode,
                TotalParentRowCode:             templateRow.TotalParentRowCode,
                Cells:                          this.createCellsFromTemplate(templateRow, rowCode, colCalcs),
                CollapseableChildrenRowCodes:   templateRow.CollapseableChildrenRowCodes,
                TotalChildrenRowCodes:          templateRow.TotalChildrenRowCodes,
                TemplateRows:                   templateRow.TemplateRows
            }
            return newRow;
        }

        createCellsFromTemplate(templateRow: ExhibitGrid.ViewModel.IRowVm, rowCode: string, colCalcs: ExhibitGrid.ViewModel.ICalcExpressionVm[]) {
            var cells = [];
            var expandedColCalcs = this.CalcService.expandColCalcsForCell(colCalcs, rowCode);
            _.forEach(templateRow.Cells, templateCell => {
                var newCell: ExhibitGrid.ViewModel.ICellVm = {
                    GridCode:       templateCell.GridCode,
                    RowCode:        rowCode,
                    ColCode:        templateCell.ColCode,
                    ColSpan:        templateCell.ColSpan,
                    ColumnHeader:   templateCell.ColumnHeader,
                    Width:          templateCell.Width,
                    IsEditable:     templateCell.IsEditable,
                    Type:           templateCell.Type,
                    Value:          templateCell.Value,
                    Indent:         templateCell.Indent,
                    IsHidden:       templateCell.IsHidden,
                    Alignment:      templateCell.Alignment,
                    MaxChars:       templateCell.MaxChars,
                    DecimalPlaces:  templateCell.DecimalPlaces,
                    HoverBase:      templateCell.HoverBase,
                    HoverAddition:  templateCell.HoverAddition,
                    TextColor:      templateCell.TextColor,
                    Calcs:          this.getColCalcsForCell(expandedColCalcs, templateCell.GridCode, rowCode, templateCell.ColCode)
                }
                cells.push(newCell);
            });
            return cells;
        }

        getColCalcsForCell(expandedColCalcs: ExhibitGrid.ViewModel.ICalcExpressionVm[], gridCode: string, rowCode: string, colCode: string) {
            //Filter expanded col calcs where any operand is the specified gridcode/rowcode/colcode 
            return _.filter(expandedColCalcs, function (expandedColCalc) {
                return _.some(expandedColCalc.Operands, function(operand) {
                    return operand.GridCode == gridCode && operand.RowCode == rowCode && operand.ColCode == colCode;
                });
            });
        }
        
        getNextChildRowNumber(preExistingChildRows: ExhibitGrid.ViewModel.IRowVm[]) {
            var childNums = [0];
            _.forEach(preExistingChildRows, childRow => {
                var endingNum = 0;
                var splitRowCode = childRow.RowCode.split("_");
                if (splitRowCode.length > 1) {
                    var lastSectionOfRowCode = splitRowCode[splitRowCode.length - 1];
                    var parsedNum = parseInt(lastSectionOfRowCode);
                    if (!isNaN(parsedNum)) {
                        endingNum = parsedNum;
                    }
                }
                childNums.push(endingNum);
            });
            return _.max(childNums);
        }

        getNextDisplayOrder(preExistingChildRows: ExhibitGrid.ViewModel.IRowVm[], parentRowOrder: number) {
            var displayOrder = parentRowOrder;
            _.forEach(preExistingChildRows, childRow => {
                if (childRow.DisplayOrder > displayOrder) {
                    displayOrder = childRow.DisplayOrder;
                }
            });
            return displayOrder;
        }

        deleteRow(rowVm: ExhibitGrid.ViewModel.IRowVm) {
            //delete all references from parent (collapse children, total children)
            var collapseParentVm;
            if (rowVm.CollapseParentRowCode) {
                collapseParentVm = this.ModelService.getRowVm(rowVm.GridCode, rowVm.CollapseParentRowCode);
                _.remove(collapseParentVm.CollapseableChildrenRowCodes, childRowCode => {
                    return childRowCode == rowVm.RowCode;
                })
            }
            var totalParentVm: ExhibitGrid.ViewModel.IRowVm;
            if (rowVm.TotalParentRowCode) {
                if (collapseParentVm && rowVm.CollapseParentRowCode == rowVm.TotalParentRowCode) {
                    totalParentVm = collapseParentVm;
                }
                else{
                    totalParentVm = this.ModelService.getRowVm(rowVm.GridCode, rowVm.TotalParentRowCode);
                }
                _.remove(totalParentVm.TotalChildrenRowCodes, childRowCode => {
                    return childRowCode == rowVm.RowCode;
                });

                for (var i = 0; i < totalParentVm.Cells.length; i++) {
                    var cell = totalParentVm.Cells[i];
                    var cellType = cell.Type.toLowerCase();
                    if (cellType === "numeric" || cellType === "percent") {
                        this.CalcService.evaluateTotalParentCellForColumn(totalParentVm, cell.ColCode);
                    }
                }
            }
            //delete references from grid
            var gridVm = this.ModelService.getGridVm(rowVm.GridCode);
            _.remove(gridVm.Rows, row => {
                return row.RowCode == rowVm.RowCode;
            })
        }
    }
    
    var service = angular
        .module('app.addRow', ['app.model', 'app.calc'])
        .service('addRowService', ['modelService', 'calcService', AddRowService]);
} 