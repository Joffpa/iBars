using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.ViewModel;

namespace ExhibitGrid.Controllers
{
    public class HomeController : Controller
    {
        private GridVm CreateNewGridVm()
        {
            var grid1 = new GridVm("PBA12_ProgData1");
            grid1.Rows = new List<RowVm>()
                    {
                        new RowVm("PBA12_ProgData_CommunHdr", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_CommunSustBase", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_CommunLongHaul", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_CommunDeplMobl", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_CmdCntrlHdr", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_CmdCntrlNatnl", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_CmdCntrlOpera", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_CmdCntrlTact", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_C3RelHdr", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_C3RelNavig", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_C3RelMetrlgy", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_C3RelCombID", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_C3RelInfoAssur", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        }),
                        new RowVm("PBA12_ProgData_TOTAL", new List<CellVm>() {
                            new CellVm("PBA12_ProgData_Py"),
                            new CellVm("PBA12_ProgData_Pyprice"),
                            new CellVm("PBA12_ProgData_Pyprog"),
                            new CellVm("PBA12_ProgData_Cy"),
                            new CellVm("PBA12_ProgData_Cyprice"),
                            new CellVm("PBA12_ProgData_Cyprog"),
                            new CellVm("PBA12_ProgData_By1"),
                            new CellVm("PBA12_ProgData_By1price"),
                            new CellVm("PBA12_ProgData_By1prog"),
                            new CellVm("PBA12_ProgData_By2"),
                        })

                    };
            return grid1;
        }

        public ActionResult GridProto()
        {
            try
            {

                using (var db = new DEV_AF())
                {
                    var grid1 = CreateNewGridVm();

                    var x = 1;
                    var spResult = db.UspGetAttribute("PBA12_ProgData1").ToList();
                    
                    //about 159 ms
                    foreach (RowVm row in grid1.Rows)
                    {
                        var rowCode = row.RowCode;
                        var rowAttribs = spResult.Where(r => r.GridCode == grid1.GridCode && r.RowCode == rowCode);
                        row.RowAttrib1 = rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib1").Value;
                        row.RowAttrib2 = rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib2").Value;
                        row.RowAttrib3 = rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib3").Value;
                        row.RowAttrib4 = rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib4").Value;
                        row.RowAttrib5 = rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib5").Value;
                        row.RowAttrib6 = rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib6").Value;
                        row.RowAttrib7 = bool.Parse(rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib7").Value);
                        row.RowAttrib8 = bool.Parse(rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib8").Value);
                        row.RowAttrib9 = bool.Parse(rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib9").Value);
                        row.RowAttrib10 = bool.Parse(rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib10").Value);
                        row.RowAttrib11 = bool.Parse(rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib11").Value);
                        row.RowAttrib12 = bool.Parse(rowAttribs.FirstOrDefault(a => a.Attrib == "RowAttrib12").Value);
                        foreach(CellVm cell in row.Cells)
                        {
                            var cellAttribs = spResult.Where(r => r.GridCode == grid1.GridCode && r.RowCode == rowCode && r.ColCode == cell.ColCode);
                            cell.CellAttrib1 = cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib1").Value;
                            cell.CellAttrib2 = cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib2").Value;
                            cell.CellAttrib3 = cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib3").Value;
                            cell.CellAttrib4 = cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib4").Value;
                            cell.CellAttrib5 = cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib5").Value;
                            cell.CellAttrib6 = cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib6").Value;
                            cell.CellAttrib7 = bool.Parse(cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib7").Value);
                            cell.CellAttrib8 = bool.Parse(cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib8").Value);
                            cell.CellAttrib9 = bool.Parse(cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib9").Value);
                            cell.CellAttrib10 = bool.Parse(cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib10").Value);
                            cell.CellAttrib11 = bool.Parse(cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib11").Value);
                            cell.CellAttrib12 = bool.Parse(cellAttribs.FirstOrDefault(a => a.Attrib == "CellAttrib12").Value);
                        }
                    }

                    x = 2;
                }

                using (var db = new DEV_AF())
                {

                    var grid2 = CreateNewGridVm();
                    var x = 3;
                    var deNormAttribs = db.AttributeDeNorms.Where(a => a.GridCode == grid2.GridCode).ToList();
                    
                    foreach (RowVm row in grid2.Rows)
                    {
                        var rowCode = row.RowCode;
                        var rowAttribs = deNormAttribs.FirstOrDefault(r => r.GridCode == grid2.GridCode && r.RowCode == rowCode && string.IsNullOrEmpty(r.ColCode));
                        row.RowAttrib1 = rowAttribs.RowAttrib1;
                        row.RowAttrib2 = rowAttribs.RowAttrib2;
                        row.RowAttrib3 = rowAttribs.RowAttrib3;
                        row.RowAttrib4 = rowAttribs.RowAttrib4;
                        row.RowAttrib5 = rowAttribs.RowAttrib5;
                        row.RowAttrib6 = rowAttribs.RowAttrib6;
                        row.RowAttrib7 = rowAttribs.RowAttrib7 ?? false;
                        row.RowAttrib8 = rowAttribs.RowAttrib8 ?? false;
                        row.RowAttrib9 = rowAttribs.RowAttrib9 ?? false;
                        row.RowAttrib10 = rowAttribs.RowAttrib10 ?? false;
                        row.RowAttrib11 = rowAttribs.RowAttrib11 ?? false;
                        row.RowAttrib12 = rowAttribs.RowAttrib12 ?? false;
                        foreach (CellVm cell in row.Cells)
                        {
                            var cellAttribs = deNormAttribs.FirstOrDefault(r => r.GridCode == grid2.GridCode && r.RowCode == rowCode && r.ColCode == cell.ColCode);
                            cell.CellAttrib1 = cellAttribs.CellAttrib1;
                            cell.CellAttrib2 = cellAttribs.CellAttrib2;
                            cell.CellAttrib3 = cellAttribs.CellAttrib3;
                            cell.CellAttrib4 = cellAttribs.CellAttrib4;
                            cell.CellAttrib5 = cellAttribs.CellAttrib5;
                            cell.CellAttrib6 = cellAttribs.CellAttrib6;
                            cell.CellAttrib7 = cellAttribs.CellAttrib7 ?? false;
                            cell.CellAttrib8 = cellAttribs.CellAttrib8 ?? false;
                            cell.CellAttrib9 = cellAttribs.CellAttrib9 ?? false;
                            cell.CellAttrib10 = cellAttribs.CellAttrib10 ?? false;
                            cell.CellAttrib11 = cellAttribs.CellAttrib11 ?? false;
                            cell.CellAttrib12 = cellAttribs.CellAttrib12 ?? false;
                        }
                    }

                    x = 4;
                }



            }
            catch (Exception e)
            {
                var x = e;
            }

            return View();
        }
    }
}
