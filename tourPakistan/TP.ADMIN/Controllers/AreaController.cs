using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetronicReady.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult AreaIndex()
        {
            return View();
        }

        public ActionResult AddArea()
        {
            return View();
        }
    }
}