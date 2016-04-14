using System;
using System.Collections.Generic;
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
            ExhibitVm exhibitVm = new ExhibitVmFactory().GetExhibitVm(gridCode);
            CalcGridProcess.Process(exhibitVm, gridCode);
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
