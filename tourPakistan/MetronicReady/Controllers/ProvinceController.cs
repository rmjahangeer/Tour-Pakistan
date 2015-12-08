using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetronicReady.Controllers
{
    public class ProvinceController : Controller
    {
        // GET: Province

        public ActionResult ProvinceIndex()
        {
            return View();
        }

        public ActionResult AddProvince()
        {
            return View();
        }

    }
}