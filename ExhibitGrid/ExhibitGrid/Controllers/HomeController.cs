using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExhibitGrid.EntityDataModel;
using ExhibitGrid.ViewModel;
using ExhibitGrid.Processes;

namespace ExhibitGrid.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult GridProto()
        {
            return View();
        }

        public ActionResult DynamicViewGrid()
        {
            var gridVm = GridVmFactory.GetGridVm("mock");
            return View(gridVm);
        }


    }
}
