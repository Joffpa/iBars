using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Extensions
{
    public static class DbContextExtensions
    {
        public static ObjectResult<CellValue> UspGetCellVal(this DbContext db, IEnumerable<CellValue> cells)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GridCode");
            dt.Columns.Add("RowCode");
            dt.Columns.Add("ColCode");

            foreach (var cell in cells)
            {
                DataRow dr = dt.NewRow();
                dr["GridCode"] = cell.GridCode;
                dr["RowCode"] = cell.RowCode;
                dr["ColCode"] = cell.ColCode;
                dt.Rows.Add(dr);
            }

            var cellParms = new SqlParameter("Cells", SqlDbType.Structured)
            {
                Value = dt,
                TypeName = "GridCells"
            };

            return ((IObjectContextAdapter)db).ObjectContext.ExecuteStoreQuery<CellValue>("EXEC UspGetCellVal @Cells", cellParms);
        }
    }
}