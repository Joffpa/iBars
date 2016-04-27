using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.ViewModel;
using ExhibitGrid.Processes;
using Newtonsoft.Json;

namespace ExhibitGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GridProto(string gridCode)
        {
            var exhibit = new ExhibitVm()
            {
                Grids = new List<GridVm>(),
                PrimaryGridCode = gridCode
            };

            var exhibitVm = ExhibitVmProcess.GetExhibitVmWithCalcs(gridCode, exhibit);
            CalcGridProcess.Process(exhibitVm, gridCode);

            foreach (var gridVm in exhibitVm.Grids)
            {
                Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Debug.WriteLine("Grid: " + gridVm.GridCode);
                Debug.WriteLine("");
                foreach (var row in gridVm.Rows)
                {
                    Debug.WriteLine("Row: " + row.RowCode);
                    foreach (var cell in row.Cells)
                    {
                        Debug.WriteLine(cell.GridCode + ", " + cell.RowCode + ", " + cell.ColCode + ":    " + cell.Value);
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("");
                Debug.WriteLine("");
                Debug.WriteLine("");
            }
            return View(exhibitVm);
        }
        
        [HttpGet]
        public JsonResult GetDdOptions(string rowCode, string colCode)
        {        var options = new List<SelectListItem>();
            options.Add(new SelectListItem()
            {
                Text = "Option 1",
                Value = "1"
            });
            options.Add(new SelectListItem()
            {
                Text = "Option 2",
                Value = "2"
            });
            options.Add(new SelectListItem()
            {
                Text = "Option 3",
                Value = "3"
            });
            options.Add(new SelectListItem()
            {
                Text = "Option 4",
                Value = "4"
            });

            return Json(options, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SpreadSheet()
        {
            return View();
        }

        public ActionResult RunCalcs()
        {
            var vm = new RunCalcVm();
            return View(vm);
        }

        [HttpPost]
        public JsonResult RunCalcs(RunCalcVm vm)
        {

            CalcGridProcess.Process(vm.ExhibitToCalc);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
    }
}
