var app;
(function (app) {
    var addRow;
    (function (addRow) {
        var AddRowService = (function () {
            function AddRowService(modelService, calcService) {
                this.ModelService = modelService;
                this.CalcService = calcService;
            }
            AddRowService.prototype.addRowsFromRowTemplate = function (parentRowVm) {
                var _this = this;
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
                var newRows = [];
                _.forEach(templateRows, function (templateRow) {
                    //increment order
                    displayOrder = displayOrder + .01;
                    //increment rowNumber
                    nextRowNum = nextRowNum + 1;
                    //create new rowcode
                    var newRowCode = parentRowVm.RowCode + "_child_" + nextRowNum.toString();
                    var newRow = _this.createRowFromTemplate(templateRow, displayOrder, newRowCode, colCalcs);
                    if (templateRow.CollapseParentRowCode) {
                        var collapseParentVm;
                        if (templateRow.CollapseParentRowCode == parentRowVm.RowCode) {
                            collapseParentVm = parentRowVm;
                        }
                        else {
                            collapseParentVm = _this.ModelService.getRowVm(templateRow.GridCode, templateRow.CollapseParentRowCode);
                        }
                        collapseParentVm.CollapseableChildrenRowCodes.push(newRow.RowCode);
                    }
                    if (templateRow.TotalParentRowCode) {
                        var totalParentVm;
                        if (templateRow.TotalParentRowCode == parentRowVm.RowCode) {
                            totalParentVm = parentRowVm;
                        }
                        else {
                            totalParentVm = _this.ModelService.getRowVm(templateRow.GridCode, templateRow.TotalParentRowCode);
                        }
                        totalParentVm.TotalChildrenRowCodes.push(newRow.RowCode);
                    }
                    grid.Rows.push(newRow);
                });
                //uncollapse parent to show new children
                this.ModelService.collapseChildren(parentRowVm, false);
            };
            AddRowService.prototype.addRowsFromGridTemplate = function (gridCode) {
            };
            AddRowService.prototype.createRowFromTemplate = function (templateRow, order, rowCode, colCalcs) {
                var newRow = {
                    GridCode: templateRow.GridCode,
                    RowCode: rowCode,
                    DisplayOrder: order,
                    Class: templateRow.Class,
                    CanCollapse: templateRow.CanCollapse,
                    CanAdd: templateRow.CanAdd,
                    CanDelete: templateRow.CanDelete,
                    CanSelect: templateRow.CanSelect,
                    IsHidden: templateRow.IsHidden,
                    IsCollapsed: false,
                    ChildrenAreCollapsed: false,
                    IsSelected: templateRow.IsSelected,
                    IsEditable: templateRow.IsEditable,
                    Type: templateRow.Type,
                    CollapseParentRowCode: templateRow.CollapseParentRowCode,
                    TotalParentRowCode: templateRow.TotalParentRowCode,
                    Cells: this.createCellsFromTemplate(templateRow, rowCode, colCalcs),
                    CollapseableChildrenRowCodes: templateRow.CollapseableChildrenRowCodes,
                    TotalChildrenRowCodes: templateRow.TotalChildrenRowCodes,
                    TemplateRows: templateRow.TemplateRows
                };
                return newRow;
            };
            AddRowService.prototype.createCellsFromTemplate = function (templateRow, rowCode, colCalcs) {
                var _this = this;
                var cells = [];
                var expandedColCalcs = this.CalcService.expandColCalcsForCell(colCalcs, rowCode);
                _.forEach(templateRow.Cells, function (templateCell) {
                    var newCell = {
                        GridCode: templateCell.GridCode,
                        RowCode: rowCode,
                        ColCode: templateCell.ColCode,
                        ColSpan: templateCell.ColSpan,
                        ColumnHeader: templateCell.ColumnHeader,
                        Width: templateCell.Width,
                        IsEditable: templateCell.IsEditable,
                        Type: templateCell.Type,
                        Value: templateCell.Value,
                        Indent: templateCell.Indent,
                        IsHidden: templateCell.IsHidden,
                        Alignment: templateCell.Alignment,
                        MaxChars: templateCell.MaxChars,
                        DecimalPlaces: templateCell.DecimalPlaces,
                        HoverBase: templateCell.HoverBase,
                        HoverAddition: templateCell.HoverAddition,
                        TextColor: templateCell.TextColor,
                        Calcs: _this.getColCalcsForCell(expandedColCalcs, templateCell.GridCode, rowCode, templateCell.ColCode)
                    };
                    cells.push(newCell);
                });
                return cells;
            };
            AddRowService.prototype.getColCalcsForCell = function (expandedColCalcs, gridCode, rowCode, colCode) {
                //Filter expanded col calcs where any operand is the specified gridcode/rowcode/colcode 
                return _.filter(expandedColCalcs, function (expandedColCalc) {
                    return _.some(expandedColCalc.Operands, function (operand) {
                        return operand.GridCode == gridCode && operand.RowCode == rowCode && operand.ColCode == colCode;
                    });
                });
            };
            AddRowService.prototype.getNextChildRowNumber = function (preExistingChildRows) {
                var childNums = [0];
                _.forEach(preExistingChildRows, function (childRow) {
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
            };
            AddRowService.prototype.getNextDisplayOrder = function (preExistingChildRows, parentRowOrder) {
                var displayOrder = parentRowOrder;
                _.forEach(preExistingChildRows, function (childRow) {
                    if (childRow.DisplayOrder > displayOrder) {
                        displayOrder = childRow.DisplayOrder;
                    }
                });
                return displayOrder;
            };
            AddRowService.prototype.deleteRow = function (rowVm) {
                //delete all references from parent (collapse children, total children)
                var collapseParentVm;
                if (rowVm.CollapseParentRowCode) {
                    collapseParentVm = this.ModelService.getRowVm(rowVm.GridCode, rowVm.CollapseParentRowCode);
                    _.remove(collapseParentVm.CollapseableChildrenRowCodes, function (childRowCode) {
                        return childRowCode == rowVm.RowCode;
                    });
                }
                var totalParentVm;
                if (rowVm.TotalParentRowCode) {
                    if (collapseParentVm && rowVm.CollapseParentRowCode == rowVm.TotalParentRowCode) {
                        totalParentVm = collapseParentVm;
                    }
                    else {
                        totalParentVm = this.ModelService.getRowVm(rowVm.GridCode, rowVm.TotalParentRowCode);
                    }
                    _.remove(totalParentVm.TotalChildrenRowCodes, function (childRowCode) {
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
                _.remove(gridVm.Rows, function (row) {
                    return row.RowCode == rowVm.RowCode;
                });
            };
            return AddRowService;
        }());
        addRow.AddRowService = AddRowService;
        var service = angular
            .module('app.addRow', ['app.model', 'app.calc'])
            .service('addRowService', ['modelService', 'calcService', AddRowService]);
    })(addRow = app.addRow || (app.addRow = {}));
})(app || (app = {}));
//# sourceMappingURL=addRowService.js.map