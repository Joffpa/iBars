
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ExhibitGrid.ViewModel;
//using ExhibitGrid.EntityDataModel;
using System.Data.Entity.Infrastructure;

namespace ProtoTests
{
    [TestClass]
    public class PerformanceTests
    {

        [TestMethod]
        public void TestReplaceInExpression()
        {
            var expression = "{grid.row.} + {grid.row.} + {grid.row.} + {grid.row.}";
            for (int i = 0; i < 300; i++)
            {
                var expanded = expression.Replace(".}", ".col}");
                Assert.AreEqual("{grid.row.col} + {grid.row.col} + {grid.row.col} + {grid.row.col}", expanded);
            }
        }

        [TestMethod]
        public void TestSplitInsertInExpression()
        {
            var expression = "{grid.row..} + {grid.row..} + {grid.row..} + {grid.row..}";
            for (int i = 0; i < 300; i++)
            {
                var split = expression.Split('.');
                var expanded = split.Aggregate((c, n) => n == "" ? c + ".col" : c + "." + n);
                Assert.AreEqual("{grid.row.col.} + {grid.row.col.} + {grid.row.col.} + {grid.row.col.}", expanded);
            }
        }

        [TestMethod]
        public void TestOperandQuery()
        {
            //using (var myDb = new ExhibitProtoEntities())
            //{
            //    var operands = myDb.CalcOperands.ToList();
            //}
        }

        //[TestMethod]
        //public void TestOperandSp()
        //{
        //    List<GetCalcs_Result> getCalcsResult;
        //    //using (var mydb = new ExhibitProtoEntities())
        //    //{
        //    //    getCalcsResult = mydb.GetCalcs("MockGrid").ToList();
        //    //}

        //    #region mock calc result
        //    getCalcsResult = new List<GetCalcs_Result>()
        //    {
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_2",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_3",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_4",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_5",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_6",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_7",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_8",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_9",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_10",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_11",
        //            ColCode = ""
        //        },
        //        new GetCalcs_Result()
        //        {
        //            TargetGridCode = "MockGrid",
        //            TargetRowCode = "Row_1",
        //            TargetColCode = "",
        //            Expression = "{Mockgrid.Row_2..} + {Mockgrid.Row_3..} + {Mockgrid.Row_4..} + {Mockgrid.Row_5..} + {Mockgrid.Row_6..} + {Mockgrid.Row_7..} + {Mockgrid.Row_8..} + {Mockgrid.Row_9..} + {Mockgrid.Row_10..} + {Mockgrid.Row_11..} + {Mockgrid.Row_12..}",
        //            GridCode = "MockGrid",
        //            RowCode = "Row_12",
        //            ColCode = ""
        //        }
        //    };

        //    #endregion

        //    List<GetCalcs_Result> rowCalcResults = new List<GetCalcs_Result>();
        //    List<GetCalcs_Result> colCalcResults = new List<GetCalcs_Result>();
        //    List<GetCalcs_Result> cellCalcResults = new List<GetCalcs_Result>();
        //    foreach (var calc in getCalcsResult)
        //    {
        //        if (string.IsNullOrEmpty(calc.TargetColCode))
        //        {
        //            rowCalcResults.Add(calc);
        //        }
        //        else if (string.IsNullOrEmpty(calc.TargetRowCode))
        //        {
        //            colCalcResults.Add(calc);
        //        }
        //        else
        //        {
        //            cellCalcResults.Add(calc);
        //        }
        //    }
        //    var allCalcExpressions = getCalcsResult.GroupBy(r => new { r.TargetGridCode, r.TargetRowCode, r.TargetColCode, r.Expression }, (key, group) => new CalcExpressionVm()
        //    {
        //        TargetGridCode = key.TargetGridCode,
        //        TargetRowCode = key.TargetRowCode,
        //        TargetColCode = key.TargetColCode,
        //        Expression = key.Expression,
        //        Operands = group.Select(g => new CalcOperandVm() { GridCode = g.GridCode, RowCode = g.RowCode, ColCode = g.ColCode }).ToList()
        //    });
        //}

        //[TestMethod]
        //public void TestMultipleResults()
        //{
        //    using (var db = new ExhibitProtoEntities())
        //    using (var connection = db.Database.Connection)
        //    {
        //        connection.Open();
        //        var command = connection.CreateCommand();
        //        command.CommandText = "EXEC [dbo].[GetExpressionAndOperands] 'MockGrid'" ;
        //        using (var reader = command.ExecuteReader())
        //        {
        //            var expressions =
        //                ((IObjectContextAdapter)db)
        //                    .ObjectContext
        //                    .Translate<Expression>(reader)
        //                    .ToList();

        //            reader.NextResult();

        //            var operands =
        //                ((IObjectContextAdapter)db)
        //                    .ObjectContext
        //                    .Translate<Operand>(reader)
        //                    .ToList();
        //        }
        //    }
        //}          
    }
}
