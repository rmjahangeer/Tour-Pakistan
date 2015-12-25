using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetronicReady.Controllers
{
    public class SeasonController : Controller
    {
        // GET: Season
        public ActionResult SeasonIndex()
        {
            return View();
        }

        public ActionResult AddSeason()
        {
            return View();
        }
    }
}