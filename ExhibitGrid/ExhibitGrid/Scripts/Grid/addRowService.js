/// <reference path="../typings/lodash/lodash-3.10.d.ts" />
'use strict';
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
                if (parentRowVm.TemplateRows == null || parentRowVm.TemplateRows.length < 1) {
                    return;
                }
                var grid = this.ModelService.getGridVm(parentRowVm.GridCode);
                //get template rows
                var templateRows = parentRowVm.TemplateRows;
                //Get ColCalcs
                var colCalcs = this.ModelService.getGridColCalcs(parentRowVm.GridCode);
                var childRowPrefix = parentRowVm.RowCode + "_child_";
                var allDecendantRows = this.getAllDecendantRows(parentRowVm, grid);
                var nextRowNum = this.getNextChildRowNumber(allDecendantRows);
                var displayOrder = parentRowVm.DisplayOrder;
                if (allDecendantRows && allDecendantRows.length > 0) {
                    displayOrder = this.getMaxOrder(allDecendantRows, grid);
                }
                var rowCodeMappings = [];
                var newRowVms = [];
                _.forEach(grid.Rows, function (rowVm) {
                    if (rowVm.DisplayOrder > displayOrder) {
                        rowVm.DisplayOrder += templateRows.length;
                    }
                });
                for (var i = 0; i < templateRows.length; i++) {
                    var templateRow = templateRows[i];
                    //increment order
                    displayOrder = displayOrder + 1;
                    //increment rowNumber
                    nextRowNum = nextRowNum + 1;
                    //create new rowcode
                    var newRowCode = childRowPrefix + nextRowNum.toString();
                    var rowCodeMapping = {
                        ActualRowCode: newRowCode,
                        TemplateRowCode: templateRow.RowCode
                    };
                    rowCodeMappings.push(rowCodeMapping);
                    var newRow = this.createRowFromTemplate(templateRow, parentRowVm, displayOrder, newRowCode, colCalcs);
                    newRowVms.push(newRow);
                }
                //Convert parent.child row codes into the newly created actual row codes if the newly created rows still reference the template rows
                for (var i = 0; i < newRowVms.length; i++) {
                    var newRowVm = newRowVms[i];
                    this.convertAllParentAndChildRowCodesToActualRowCodes(newRowVm, rowCodeMappings);
                    if (newRowVm.TemplateRows) {
                        for (var i = 0; i < newRowVm.TemplateRows.length; i++) {
                            var templateRow = newRowVm.TemplateRows[i];
                            this.convertAllParentAndChildRowCodesToActualRowCodes(templateRow, rowCodeMappings);
                        }
                    }
                    if (newRowVm.ParentRowCode == parentRowVm.RowCode) {
                        parentRowVm.ChildRowCodes.push(newRowVm.RowCode);
                    }
                }
                _.forEach(newRowVms, function (newRowVm) {
                    grid.Rows.push(newRowVm);
                });
                //uncollapse parent to show new children
                this.ModelService.collapseChildren(parentRowVm, false);
            };
            AddRowService.prototype.getAllDecendantRows = function (parentRowVm, gridVm) {
                if (!parentRowVm.ChildRowCodes || parentRowVm.ChildRowCodes.length < 1) {
                    return [];
                }
                var childRows = _.filter(gridVm.Rows, function (row) {
                    return _.includes(parentRowVm.ChildRowCodes, row.RowCode);
                });
                for (var i = 0; i < childRows.length; i++) {
                    var grandChildren = this.getAllDecendantRows(childRows[i], gridVm);
                    childRows = _.union(childRows, grandChildren);
                }
                return childRows;
            };
            AddRowService.prototype.getMaxOrder = function (rowVms, gridVm) {
                if (rowVms && rowVms.length > 0) {
                    var maxRow = rowVms[0];
                    for (var i = 1; i < rowVms.length; i++) {
                        if (rowVms[i].DisplayOrder > maxRow.DisplayOrder) {
                            maxRow = rowVms[i];
                        }
                    }
                    return maxRow.DisplayOrder;
                }
                return 1;
            };
            AddRowService.prototype.convertAllParentAndChildRowCodesToActualRowCodes = function (rowVm, rowCodeMappings) {
                var _this = this;
                if (rowVm.ParentRowCode) {
                    rowVm.ParentRowCode = this.convertTemplateRowCodeToActualRowCode(rowVm.ParentRowCode, rowCodeMappings);
                }
                ;
                if (rowVm.ChildRowCodes) {
                    var childRowCodes = [];
                    _.forEach(rowVm.ChildRowCodes, function (childRowCode) {
                        var rowCode = _this.convertTemplateRowCodeToActualRowCode(childRowCode, rowCodeMappings);
                        childRowCodes.push(rowCode);
                    });
                    rowVm.ChildRowCodes = childRowCodes;
                }
                ;
            };
            AddRowService.prototype.convertTemplateRowCodeToActualRowCode = function (rowCode, rowCodeMappings) {
                var rowCodeMap = _.find(rowCodeMappings, function (rowCodeMap) {
                    return rowCodeMap.TemplateRowCode == rowCode;
                });
                if (rowCodeMap) {
                    return rowCodeMap.ActualRowCode;
                }
                return rowCode;
            };
            AddRowService.prototype.createRowFromTemplate = function (templateRow, parentRowVm, order, rowCode, colCalcs) {
                var parentRowCode = parentRowVm.RowCode;
                if (templateRow.ParentRowCode) {
                    parentRowCode = templateRow.ParentRowCode;
                }
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
                    ParentRowCode: parentRowCode,
                    Cells: this.createCellsFromTemplate(templateRow, rowCode, colCalcs),
                    ChildRowCodes: templateRow.ChildRowCodes,
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
            AddRowService.prototype.deleteRow = function (rowVm) {
                //delete all references from parent 
                var parentRowVm;
                if (rowVm.ParentRowCode) {
                    parentRowVm = this.ModelService.getRowVm(rowVm.GridCode, rowVm.ParentRowCode);
                    _.remove(parentRowVm.ChildRowCodes, function (childRowCode) {
                        return childRowCode == rowVm.RowCode;
                    });
                    for (var i = 0; i < parentRowVm.Cells.length; i++) {
                        var cell = parentRowVm.Cells[i];
                        var cellType = cell.Type.toLowerCase();
                        if (cellType === "numeric" || cellType === "percent") {
                            this.CalcService.evaluateTotalParentCellForColumn(parentRowVm, cell.ColCode);
                        }
                    }
                }
                if (rowVm.ChildRowCodes && rowVm.ChildRowCodes.length > 0) {
                    var i = rowVm.ChildRowCodes.length;
                    while (i--) {
                        var childRowVm = this.ModelService.getRowVm(rowVm.GridCode, rowVm.ChildRowCodes[i]);
                        this.deleteRow(childRowVm);
                    }
                }
                var gridVm = this.ModelService.getGridVm(rowVm.GridCode);
                //delete references from grid
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