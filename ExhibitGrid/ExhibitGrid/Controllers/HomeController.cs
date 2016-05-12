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
                Grids = new List<GridVm>()
            };

            var exhibitVm = ExhibitVmProcess.GetGridVmForUi(gridCode, exhibit);
            if (gridCode == "CalcGrid1")
            {
                exhibitVm = ExhibitVmProcess.GetGridVmForUi("CalcGrid2", exhibitVm);
            }
            CalcGridProcess.Process(exhibitVm, gridCode);

            if (gridCode == "CalcGrid1")
            {
                CalcGridProcess.Process(exhibitVm, "CalcGrid2");
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
