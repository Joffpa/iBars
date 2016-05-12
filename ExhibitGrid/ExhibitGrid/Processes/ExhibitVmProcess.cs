using System;
using System.Collections.Generic;
using System.Linq;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.Extensions;
using ExhibitGrid.Globals;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Processes
{
    public class ExhibitVmProcess
    {
        
        /// <summary>
        /// Retrieves GridVm from DB and builds a partial model, excluding calculations and template rows. If there are any cells from other grids that this grid is dependent upon (e.g. calcs that
        /// have operands from other grids) then additional, partially formed, GridVm's will be created for just those external dependent cells.
        /// </summary>
        /// <param name="gridCode"></param>
        /// <returns></returns>
        public static ExhibitVm GetGridVmForMidtierCalcs(string gridCode)
        {
            var exhibit = InitializeNewExhibit();
            var grid = InitializeNewGrid(gridCode, true);
            //Make sure any pre existing or partially formed grids are removed with this grid code
            exhibit.Grids.RemoveAll(g => g.GridCode == gridCode);
            exhibit.Grids.Add(grid);
            try
            {
                using (var db = new DEV_AF())
                {
                    var attribs = db.UspGetAttribVal(gridCode).ToList();
                    var rowRelations = db.UspGetRowRelationship(gridCode, null).ToList();
                    var templateRowCodes = new List<string>();
                    var templateRowRelations = rowRelations.Where(IsTemplateRelationContext).ToList();
                    if (templateRowRelations.Any())
                    {
                        templateRowCodes = templateRowRelations.Select(tr => tr.ChRowCode).ToList();
                    }
                    var cellDictionary = new Dictionary<string, Attributes>();
                    foreach (var attrib in attribs)
                    {
                        if (!string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            cellDictionary.Add(attrib.GridCode + attrib.RowCode + attrib.ColCode, attrib);
                        }
                        else if (string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            grid.Columns.Add(BuildColVmFromAttributes(attrib));
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            SetGridAttribsFromRowAttribs(grid, attrib);

                            var row = BuildRowVmFromAttributes(attrib, rowRelations);
                            var isTemplateRow = templateRowCodes.Contains(row.RowCode);
                            if (!isTemplateRow)
                            {
                                grid.Rows.Add(row);
                            }
                        }
                        else
                        {
                            //grid.IsEditable = attrib.IsEditable ?? true;   TODO - add this back in later
                            //grid.DisplayText = attrib.DisplayText;
                        }
                    }

                    foreach (var row in grid.Rows)
                    {
                        foreach (var col in grid.Columns.Where(c => c.Level == 0).OrderBy(c => c.DisplayOrder))
                        {
                            var cellAttrib = cellDictionary[grid.GridCode + row.RowCode + col.ColCode];
                            var cell = BuildCellVmFromAttributes(grid, row, col, cellAttrib);
                            
                            row.Cells.Add(cell);
                            col.Cells.Add(cell);
                        }
                    }
                }
            }catch (Exception e)
            {
                
            }
            return exhibit;
        }
        
        /// <summary>
        /// Retrieves GridVm from DB and builds the full model, including calculations and template rows. If there are any cells from other grids that this grid is dependent upon (e.g. calcs that
        /// have operands from other grids) then additional, partially formed, GridVm's will be created for just those external dependent cells.
        /// </summary>
        /// <param name="gridCode">The GridCode the be built from the DB.</param>
        /// <param name="exhibit">OPTIONAL: The ExhibitVm that the GridVm (along with any other partially formed dependent gridvm's) will be added to. If null, a new ExhibitVm is instantiated.</param>
        /// <returns></returns>
        public static ExhibitVm GetGridVmForUi(string gridCode, ExhibitVm exhibit = null)
        {
            if (exhibit == null)
            {
                exhibit = InitializeNewExhibit();
            }
            var grid = InitializeNewGrid(gridCode, true);
            //Make sure any pre existing or partially formed grids are removed with this grid code
            exhibit.Grids.RemoveAll(g => g.GridCode == gridCode);
            exhibit.Grids.Add(grid);
            try
            {
                using (var db = new DEV_AF())
                {
                    //Make calls to DB for Calcs, Attributes, and Row Relationships, and various parms
                    var calcs = db.UspGetCalcs(gridCode).ToList();
                    var rowRelations = db.UspGetRowRelationship(gridCode, null).ToList();
                    var attribs = db.UspGetAttribVal(gridCode).ToList();
                    var showNegativeInParen = false;
                    var negativeParm = db.LOAD_PARAMETERS.FirstOrDefault(p => p.parm_name == "ShowNegativeInParensInUI");
                    if (negativeParm != null)
                    {
                        showNegativeInParen = negativeParm.parm_value == "Y";
                    }
                    grid.ShowNegativeNumsInParens = showNegativeInParen;

                    //Initalize calc objects
                    List<UspGetCalcs_Result> rowCalcResults = new List<UspGetCalcs_Result>();
                    List<UspGetCalcs_Result> cellCalcsExpandedFromRowCalcs = new List<UspGetCalcs_Result>();
                    List<UspGetCalcs_Result> colCalcResults = new List<UspGetCalcs_Result>();
                    List<UspGetCalcs_Result> cellCalcsExpandedFromColCalcs = new List<UspGetCalcs_Result>();
                    List<UspGetCalcs_Result> cellCalcResults = new List<UspGetCalcs_Result>();
                    //Initalize model for storing cells outside the current grid
                    var externalDependantCells = new List<CellVm>();
                    //Sort Calcs into RowCalcs, ColCalcs, and Cell Calcs. Also identify any Cells that the calcs are dependent upon that are outside of this grid
                    foreach (var calc in calcs)
                    {
                        if (string.IsNullOrEmpty(calc.TargetColCode) && calc.TargetGridCode == grid.GridCode)
                        {
                            rowCalcResults.Add(calc);
                        }
                        else if (string.IsNullOrEmpty(calc.TargetRowCode) && calc.TargetGridCode == grid.GridCode)
                        {
                            colCalcResults.Add(calc);
                        }
                        else
                        {
                            cellCalcResults.Add(calc);

                            //identify external cells
                            if (calc.TargetGridCode != grid.GridCode && !externalDependantCells.Any(externalCell => CellIsTargetOfCalc(externalCell, calc)))
                            {
                                externalDependantCells.Add(new CellVm()
                                {
                                    GridCode = calc.TargetGridCode,
                                    RowCode = calc.TargetRowCode,
                                    ColCode = calc.TargetColCode
                                });
                            }
                            //Both target and operand may be external
                            if (calc.GridCode != grid.GridCode && !externalDependantCells.Any(externalCell => CellIsOperandOfCalc(externalCell, calc)))
                            {
                                externalDependantCells.Add(new CellVm()
                                {
                                    GridCode = calc.GridCode,
                                    RowCode = calc.RowCode,
                                    ColCode = calc.ColCode
                                });
                            }
                        }
                    }

                    //ColCalcs will need to be expanded in UI when a user adds a row, save the unexpanded col calcs in the grid Vm
                    grid.ColCalcs.AddRange(GroupCalcResultsIntoExpressionVm(colCalcResults));
                    //Cell calcs do not need to be expanded, group the cellCalcResults into a collection of CalcExpressionVm
                    var calcExpressions = new List<CalcExpressionVm>();
                    calcExpressions.AddRange(GroupCalcResultsIntoExpressionVm(cellCalcResults));

                    var templateRowCodes = new List<string>();
                    var templateRowRelations = rowRelations.Where(IsTemplateRelationContext).ToList();
                    if (templateRowRelations.Any())
                    {
                        templateRowCodes = templateRowRelations.Select(tr => tr.ChRowCode).ToList();
                    }
                    var cellDictionary = new Dictionary<string, Attributes>();
                    var templateRowVms = new List<RowVm>();

                    foreach (var attrib in attribs)
                    {
                        if (!string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            cellDictionary.Add(attrib.GridCode + attrib.RowCode + attrib.ColCode, attrib);
                        }
                        else if (string.IsNullOrEmpty(attrib.RowCode) && !string.IsNullOrEmpty(attrib.ColCode))
                        {
                            grid.Columns.Add(BuildColVmFromAttributes(attrib));

                            //For Numeric columns expand the row calcs for every column and add to cell calcs
                            if (IsNumericOrPercentType(attrib.Type))
                                cellCalcsExpandedFromRowCalcs.AddRange(
                                    rowCalcResults.Select(rowCalc => new UspGetCalcs_Result()
                                    {
                                        CalcExpressionId = rowCalc.CalcExpressionId,
                                        TargetGridCode = rowCalc.TargetGridCode,
                                        TargetRowCode = rowCalc.TargetRowCode,
                                        TargetColCode = attrib.ColCode,
                                        UpdateContext = rowCalc.UpdateContext,
                                        Expression =
                                            rowCalc.Expression.Split('.')
                                                .Aggregate(
                                                    (c, n) => n == "" ? c + "." + attrib.ColCode + n : c + "." + n),
                                        GridCode = rowCalc.GridCode,
                                        RowCode = rowCalc.RowCode,
                                        ColCode = attrib.ColCode
                                    })
                                    .Where(rowCalc => !cellCalcResults.Any(cellCalc => CalcsHaveMatchingTargets(cellCalc, rowCalc) && CalcUpdatesCellValue(cellCalc))));
                        }
                        else if (!string.IsNullOrEmpty(attrib.RowCode) && string.IsNullOrEmpty(attrib.ColCode))
                        {
                            var row = BuildRowVmFromAttributes(attrib, rowRelations);
                            var isTemplateRow = templateRowCodes.Contains(row.RowCode);
                            if (isTemplateRow)
                            {
                                templateRowVms.Add(row);
                            }
                            else
                            {
                                grid.Rows.Add(row);
                            }

                            SetGridAttribsFromRowAttribs(grid, attrib);
                            if (attrib.Type == Literals.Attribute.RowType.Header || attrib.Type == Literals.Attribute.RowType.Blank || isTemplateRow) continue;

                            cellCalcsExpandedFromColCalcs.AddRange(
                                        colCalcResults.Select(colCalc => new UspGetCalcs_Result()
                                        {
                                            CalcExpressionId = colCalc.CalcExpressionId,
                                            TargetGridCode = colCalc.TargetGridCode,
                                            TargetRowCode = attrib.RowCode,
                                            TargetColCode = colCalc.TargetColCode,
                                            UpdateContext = colCalc.UpdateContext,
                                            Expression = colCalc.Expression.Split('.').Aggregate((c, n) => n == "" ? c + "." + attrib.RowCode + n : c + "." + n),
                                            GridCode = colCalc.GridCode,
                                            RowCode = attrib.RowCode,
                                            ColCode = colCalc.ColCode
                                        })
                                        .Where(colCalc => !cellCalcResults.Any(cellCalc => CalcsHaveMatchingTargets(cellCalc, colCalc) && CalcUpdatesCellValue(cellCalc)))
                                    );
                        }
                        else
                        {
                            //grid.IsEditable = attrib.IsEditable ?? true;   TODO - add this back in later
                            //grid.DisplayText = attrib.DisplayText;
                        }
                    }
                    
                    var colCalcExpressions = new List<CalcExpressionVm>();
                    colCalcExpressions.AddRange(GroupCalcResultsIntoExpressionVm(cellCalcsExpandedFromColCalcs));

                    var rowCalcExpressions = new List<CalcExpressionVm>();
                    rowCalcExpressions.AddRange(GroupCalcResultsIntoExpressionVm(cellCalcsExpandedFromRowCalcs));

                    var allExpandedCalcs = new List<UspGetCalcs_Result>();
                    allExpandedCalcs.AddRange(cellCalcResults);
                    allExpandedCalcs.AddRange(cellCalcsExpandedFromRowCalcs);
                    allExpandedCalcs.AddRange(cellCalcsExpandedFromColCalcs);
                    
                    //Convert all calcs into dictionaries for easy lookup when building individual cells
                    var cellCalcDic = ConvertCalcsToDictionary(calcExpressions);
                    var colCalcDic = ConvertCalcsToDictionary(colCalcExpressions);
                    var rowCalcDic = ConvertCalcsToDictionary(rowCalcExpressions);

                    if (externalDependantCells.Any())
                    {
                        GetExternalCells(exhibit, externalDependantCells, db, allExpandedCalcs, cellCalcDic, colCalcDic, rowCalcDic);
                    }
                    //remove expanded row and col calcs that target the same cell as a cell calc
                    //colCalcDic = colCalcDic.Where(cc => !cellCalcDic.Keys.Contains(cc.Key)).ToDictionary(source => source.Key, source => source.Value);
                    //rowCalcDic = rowCalcDic.Where(cc => !cellCalcDic.Keys.Contains(cc.Key)).ToDictionary(source => source.Key, source => source.Value);
                    
                    //Add Template Rows 
                    foreach (var templateRow in templateRowVms)
                    {
                        foreach (var col in grid.Columns.Where(c => c.Level == 0).OrderBy(c => c.DisplayOrder))
                        {
                            var cellAttrib = cellDictionary[grid.GridCode + templateRow.RowCode + col.ColCode];
                            templateRow.Cells.Add(BuildCellVmFromAttributes(grid, templateRow, col, cellAttrib));
                        }
                    }
                    
                    foreach (var row in grid.Rows)
                    {
                        var templateRows = templateRowRelations.Where(rr => rr.ParRowCode == row.RowCode).ToList();
                        if (templateRows.Any())
                        {
                            var childTemplateRowCodes = templateRows.Select(tr => tr.ChRowCode);
                            row.TemplateRows = templateRowVms.Where(r => childTemplateRowCodes.Contains(r.RowCode)).OrderBy(t => t.DisplayOrder).ToList();
                        }

                        foreach (var col in grid.Columns.Where(c => c.Level == 0).OrderBy(c => c.DisplayOrder))
                        {
                            var cellAttrib = cellDictionary[grid.GridCode + row.RowCode + col.ColCode];
                            var cell = BuildCellVmFromAttributes(grid, row, col, cellAttrib);
                            cell.Calcs = IsNumericOrPercentType(col.Type)
                                ? GetCalcsForCell(allExpandedCalcs, cellCalcDic, colCalcDic, rowCalcDic, grid.GridCode, row.RowCode, col.ColCode)
                                : null;

                            row.Cells.Add(cell);
                            col.Cells.Add(cell);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var x = e;
            }
            return exhibit;
        }
        

        /// <summary>
        /// Pass in a collection of cells, and retrieve the values for those cells from the DB. The cells and their values are added to the ExhibitVm (if they dont already exist).
        /// Cells are added in the same structure as a normal GridVm, but the full GridVm is not built, only the necessary Rows/Cells are added to this GridVm. Thus only a partial GridVm 
        /// is created for just the cells you specify.
        /// </summary>
        /// <param name="exhibit">The exhibit to add the resulting GridVm/RowVm/CellVm's to.</param>
        /// <param name="cells">The collection of cells to pull back from the DB.</param>
        /// <param name="db">The DbContext</param>
        /// <param name="allExpandedCalcs">All the "Expanded" calculations (row and col calcs expanded to cell calcs, plus the explicit cell calcs). Used for building the CellVm</param>
        /// <param name="cellCalcDic">The dictionary of </param>
        /// <param name="colCalcDic"></param>
        /// <param name="rowCalcDic"></param>
        public static void GetExternalCells(ExhibitVm exhibit, List<CellVm> cells, DEV_AF db, List<UspGetCalcs_Result> allExpandedCalcs, Dictionary<string, CalcExpressionVm> cellCalcDic, Dictionary<string, CalcExpressionVm> colCalcDic, Dictionary<string, CalcExpressionVm> rowCalcDic)
        {
            var cellParms = cells.Select(cell => new CellValue()
            {
                GridCode = cell.GridCode,
                RowCode = cell.RowCode,
                ColCode = cell.ColCode
            }).ToList();


            var result = db.UspGetCellVal(cellParms).ToList();
            foreach (var cellResult in result)
            {
                var grid = exhibit.Grids.FirstOrDefault(g => g.GridCode == cellResult.GridCode);
                if (grid == null)
                {
                    grid = InitializeNewGrid(cellResult.GridCode, false);
                    exhibit.Grids.Add(grid);
                }
                var row = grid.Rows.FirstOrDefault(r => r.RowCode == cellResult.RowCode);
                if (row == null)
                {
                    row = BuildRowVmForExternalGrid(cellResult.GridCode, cellResult.RowCode);
                    grid.Rows.Add(row);
                }
                var cellvm = row.Cells.FirstOrDefault(r => r.ColCode == cellResult.ColCode);
                if (cellvm == null)
                {
                    cellvm = BuildCellVmForExternalGrid(allExpandedCalcs, cellCalcDic, colCalcDic, rowCalcDic, cellResult.GridCode, cellResult.RowCode, cellResult.ColCode, cellResult.Val);
                    row.Cells.Add(cellvm);
                }
                else
                {
                    //I dont want to pull from DB actually, what's in memory is probabbly most up to date
                    //cellvm.Value = cellResult.Val;
                }
            }
        }

        #region Build Vms
        private static ExhibitVm InitializeNewExhibit()
        {
            return new ExhibitVm()
            {
                Grids = new List<GridVm>()
            };
        }

        private static GridVm InitializeNewGrid(string gridCode, bool isRendered)
        {
            return new GridVm()
            {
                GridCode = gridCode,
                IsRendered = isRendered,
                Columns = new List<ColumnVm>(),
                Rows = new List<RowVm>(),
                IsEditable = true,
                HasSelectCol = false,
                HasCollapseCol = false,
                HasAddCol = false,
                HasDeleteCol = false,
                ShowNegativeNumsInParens = false,
                ColCalcs = new List<CalcExpressionVm>()
            };
        }

        private static ColumnVm BuildColVmFromAttributes(Attributes attrib)
        {
            return new ColumnVm()
            {
                ColCode = attrib.ColCode,
                ColSpan = attrib.ColSpan ?? 1,
                Type = attrib.Type,
                MaxChars = attrib.MaxChars,
                DecimalPlaces = attrib.DecimalPlaces,
                DisplayOrder = attrib.DisplayOrder ?? new decimal(1.0),
                DisplayText = attrib.DisplayText,
                HasHeader = attrib.HasHeader ?? true,
                IsHidden = attrib.IsHidden ?? false,
                Level = attrib.Level ?? 0,
                Width = attrib.Width,
                IsEditable = attrib.IsEditable ?? false,
                Alignment = attrib.Alignment,
                Cells = new List<CellVm>()
            };
        }

        private static RowVm BuildRowVmFromAttributes(Attributes attrib, List<UspGetRowRelationship_Result> relations)
        {
            //NOTE: We do not append template rows here, as the template rows may not have been built at this point.
            //Template Rows are added later in the GetGridVmForUi method
            var thisRowsParentRelations = relations.Where(r => r.ChRowCode == attrib.RowCode).ToList();
            //Do not include template row codes in the child arrays for collapsing/totaling
            var templateRowCodes = relations.Where(r => r.ParRowCode == attrib.RowCode && String.Equals(r.Context, Literals.RowRelationshipContext.Template)).Select(r => r.ChRowCode).ToList();
            var thisRowsChildRelations = relations.Where(r => r.ParRowCode == attrib.RowCode && !templateRowCodes.Contains(r.ChRowCode)).ToList();
            var parentTotalRowCode = "";
            var parentTotalRealtion = thisRowsParentRelations.FirstOrDefault(IsTotalRelationContext);
            if (parentTotalRealtion != null)
            {
                parentTotalRowCode = parentTotalRealtion.ParRowCode;
            }
            var parentCollapseRowCode = "";
            var parentCollapseRealtion = thisRowsParentRelations.FirstOrDefault(IsCollapseRelationContext);
            if (parentCollapseRealtion != null)
            {
                parentCollapseRowCode = parentCollapseRealtion.ParRowCode;
            }
            return new RowVm()
            {
                GridCode = attrib.GridCode,
                RowCode = attrib.RowCode,
                Type = attrib.Type,
                CanSelect = attrib.CanSelect ?? false,
                CanCollapse = attrib.CanCollapse ?? false,
                CanAdd = attrib.CanAdd ?? false,
                CanDelete = attrib.CanDelete ?? false,
                Cells = new List<CellVm>(),
                Class = GetRowClassByType(attrib.Type),
                DisplayOrder = attrib.DisplayOrder ?? 0,
                IsSelected = false,
                IsCollapsed = thisRowsParentRelations.Any(IsCollapseRelationContext),
                ChildrenAreCollapsed = true,
                IsHidden = attrib.IsHidden ?? false,
                IsEditable = attrib.IsEditable ?? false,
                CollapseParentRowCode = parentCollapseRowCode,
                CollapseableChildrenRowCodes = thisRowsChildRelations.Where(IsCollapseRelationContext).Select(r => r.ChRowCode).ToList(),
                TotalChildrenRowCodes = thisRowsChildRelations.Where(IsTotalRelationContext).Select(r => r.ChRowCode).ToList(),
                TotalParentRowCode = parentTotalRowCode
            };
        }

        private static CellVm BuildCellVmFromAttributes(GridVm grid, RowVm row, ColumnVm col, Attributes cellAttrib)
        {
            var overrideColSettings = cellAttrib.OverrideColSettings ?? false;
            var cellType = overrideColSettings ? cellAttrib.Type            : col.Type;
            var decimals = overrideColSettings ? cellAttrib.DecimalPlaces   : col.DecimalPlaces;
            var maxChars = overrideColSettings ? cellAttrib.MaxChars        : col.MaxChars;
            var cellVal = cellAttrib.Value;
            var textColor = "";
            if (row.Type != Literals.Attribute.RowType.Blank && (IsNumericOrPercentType(cellType)))
            {
                double parsedNum;
                var parsed = double.TryParse(cellAttrib.Value, out parsedNum);
                if (parsed)
                {
                    cellVal = String.Format("{0:n" + decimals + "}", parsedNum);
                    //if (parsedNum < 0) textColor = "red";
                }
            }
            if (!string.IsNullOrEmpty(cellAttrib.HoverBase)) textColor = "green";
            if (!string.IsNullOrEmpty(cellAttrib.HoverAddition))
            {
                double parsedHoverAddition;
                var parsed = double.TryParse(cellAttrib.HoverAddition, out parsedHoverAddition);
                if (parsed && parsedHoverAddition != 0)
                {
                    textColor = "red";
                }
            }
            //var valParsed = double.TryParse(cellVal, out numval);
            var span = cellAttrib.ColSpan ?? col.ColSpan;
            return new CellVm()
            {
                GridCode = grid.GridCode,
                RowCode = row.RowCode,
                ColCode = col.ColCode,
                Type = cellType,
                MaxChars = maxChars,
                DecimalPlaces = decimals,
                ColSpan = GetCellSpan(grid, row, col, cellAttrib.ColSpan),
                ColumnHeader = col.DisplayText,
                Indent = cellAttrib.Indent ?? 0,
                IsEditable = (cellAttrib.IsEditable ?? false) && row.IsEditable && col.IsEditable && grid.IsEditable,
                IsHidden = cellAttrib.IsHidden ?? false,
                Value = cellVal,
                //NumValue = valParsed ? numval : 0,
                Width = (span == 1 ? col.Width : "100%"),
                Alignment = cellAttrib.Alignment ?? "right",
                HoverBase = cellAttrib.HoverBase,
                HoverAddition = cellAttrib.HoverAddition,
                TextColor = textColor,
                Calcs = null
            };
        }
                
        private static CellVm BuildCellVmForExternalGrid(List<UspGetCalcs_Result> allExpandedCalcs, Dictionary<string, CalcExpressionVm> cellCalcDic, Dictionary<string, CalcExpressionVm> colCalcDic, Dictionary<string, CalcExpressionVm> rowCalcDic, string gridCode, string rowCode, string colCode, string value)
        {
            return new CellVm
            {
                GridCode = gridCode,
                RowCode = rowCode,
                ColCode = colCode,
                Value = value,
                Calcs = GetCalcsForCell(allExpandedCalcs, cellCalcDic, colCalcDic, rowCalcDic, gridCode, rowCode, colCode)
            };
        }

        private static RowVm BuildRowVmForExternalGrid(string gridCode, string rowCode)
        {
            return new RowVm()
            {
                GridCode = gridCode,
                RowCode = rowCode,
                Cells = new List<CellVm>()
            };
        }

        private static List<CalcExpressionVm> GroupCalcResultsIntoExpressionVm(List<UspGetCalcs_Result> calcResults)
        {
            return calcResults.GroupBy(
                r =>
                    new
                    {
                        r.CalcExpressionId,
                        r.TargetGridCode,
                        r.TargetRowCode,
                        r.TargetColCode,
                        r.Expression,
                        r.UpdateContext
                    },
                (key, group) => new CalcExpressionVm()
                {
                    CalcExpressionId = key.CalcExpressionId,
                    TargetGridCode = key.TargetGridCode,
                    TargetRowCode = key.TargetRowCode,
                    TargetColCode = key.TargetColCode,
                    Expression = key.Expression,
                    UpdateContext = key.UpdateContext,
                    Operands =
                        group.Select(
                            g =>
                                new CalcOperandVm()
                                {
                                    GridCode = g.GridCode,
                                    RowCode = g.RowCode,
                                    ColCode = g.ColCode
                                }).ToList()
                }).ToList();
        }
        
        public static Dictionary<string, CalcExpressionVm> ConvertCalcsToDictionary(List<CalcExpressionVm> calcs)
        {
            return calcs.ToDictionary(calc => calc.CalcExpressionId + "." + calc.TargetGridCode + "." + calc.TargetRowCode + "." + calc.TargetColCode, source => source);
        } 

        private static List<CalcExpressionVm> GetCalcsForCell(List<UspGetCalcs_Result> allExpandedCalcs, Dictionary<string, CalcExpressionVm> cellCalcDic, Dictionary<string, CalcExpressionVm> colCalcDic, Dictionary<string, CalcExpressionVm> rowCalcDic, string gridCode, string rowCode, string colCode)
        {
            var thisCellsCalcTargets = allExpandedCalcs.Where(cc => cc.GridCode == gridCode && cc.RowCode == rowCode && cc.ColCode == colCode).Select(ac => ac.CalcExpressionId + "." + ac.TargetGridCode + "." + ac.TargetRowCode + "." + ac.TargetColCode);
            var thisCellsCalcs = new List<CalcExpressionVm>();
            thisCellsCalcs.AddRange(cellCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            thisCellsCalcs.AddRange(colCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            thisCellsCalcs.AddRange(rowCalcDic.Where(dc => thisCellsCalcTargets.Contains(dc.Key)).Select(dc => dc.Value).ToList());
            return thisCellsCalcs;
        }
        #endregion

        #region Programatically derive attributes that are not stored in DB 
        private static void SetGridAttribsFromRowAttribs(GridVm grid, Attributes rowAttrib)
        {
            grid.HasSelectCol = (rowAttrib.CanSelect ?? false) || grid.HasSelectCol;
            grid.HasCollapseCol = (rowAttrib.CanCollapse ?? false) || grid.HasCollapseCol;
            grid.HasAddCol = (rowAttrib.CanAdd ?? false) || grid.HasAddCol;
            grid.HasDeleteCol = (rowAttrib.CanDelete ?? false) || grid.HasDeleteCol;
        }
        
        private static string GetRowClassByType(string rowType)
        {
            switch (rowType)
            {
                case Literals.Attribute.RowType.Header:
                    return "header-row";
                case Literals.Attribute.RowType.Data:
                    return "data-row";
                case Literals.Attribute.RowType.Total:
                    return "total-row";
                case Literals.Attribute.RowType.Subtotal:
                    return "subtotal-row";
                case Literals.Attribute.RowType.Blank:
                    return "blank-row";
                default :
                    return "default-row";
            }
        }

        private static int GetCellSpan(GridVm grid, RowVm row, ColumnVm col, int? cellSpanAttrib)
        {
            if (row.Type != Literals.Attribute.RowType.Header && row.Type != Literals.Attribute.RowType.Blank) return cellSpanAttrib ?? col.ColSpan;

            if (col.ColCode != Literals.UniversalColCode.RowText) return 0;

            var span = grid.Columns.Count(c => c.Level == 0 && !c.IsHidden);
            span += (grid.HasSelectCol ? 1 : 0) + (grid.HasCollapseCol ? 1 : 0) + (grid.HasAddCol ? 1 : 0) + (grid.HasDeleteCol ? 1 : 0);
            return span;
        }
        #endregion
        
        #region Predicates
        private static bool IsTotalRelationContext(UspGetRowRelationship_Result relation)
        {
            return String.Equals(relation.Context, Literals.RowRelationshipContext.Total, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsCollapseRelationContext(UspGetRowRelationship_Result relation)
        {
            return String.Equals(relation.Context, Literals.RowRelationshipContext.Collapse, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsTemplateRelationContext(UspGetRowRelationship_Result relation)
        {
            return String.Equals(relation.Context, Literals.RowRelationshipContext.Template, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsNumericOrPercentType(string type)
        {
            return String.Equals(type, Literals.Attribute.ColCellType.Numeric, StringComparison.CurrentCultureIgnoreCase) ||
                String.Equals(type, Literals.Attribute.ColCellType.Percent, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool CellIsTargetOfCalc(CellVm cell, UspGetCalcs_Result calcResult)
        {
            return cell.GridCode == calcResult.TargetGridCode && cell.RowCode == calcResult.TargetRowCode && cell.ColCode == calcResult.TargetColCode;
        }

        private static bool CellIsOperandOfCalc(CellVm cell, UspGetCalcs_Result calcResult)
        {
            return cell.GridCode == calcResult.GridCode && cell.RowCode == calcResult.RowCode && cell.ColCode == calcResult.ColCode;
        }

        private static bool CalcsHaveMatchingTargets(UspGetCalcs_Result calcResult1, UspGetCalcs_Result calcResult2)
        {
            return calcResult1.TargetGridCode == calcResult2.TargetGridCode &&
                   calcResult1.TargetRowCode == calcResult2.TargetRowCode &&
                   calcResult1.TargetColCode == calcResult2.TargetColCode;
        }

        private static bool CalcUpdatesCellValue(UspGetCalcs_Result calc)
        {
            return String.Equals(calc.UpdateContext, Literals.CalcUpdateContext.CellValue, StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion
    }
}
