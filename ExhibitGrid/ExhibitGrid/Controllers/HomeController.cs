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
            var gridVm = GridVmFactory.GetGridVmV2("mock");
            return View(gridVm);
        }

        //public ActionResult DynamicViewGrid()
        //{
        //    var gridVm = GridVmFactory.GetGridVmV2("mock");
        //    return View(gridVm);
        //}

        //public ActionResult NowIGottaMakeItATableThanksALotKaren()
        //{
        //    var gridVm = GridVmFactory.GetGridVmV2("mock");
        //    return View(gridVm);
        //}

    }
}
