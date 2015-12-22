using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetronicReady.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult EventIndex()
        {
            return View();
        }

        public ActionResult AddEvent()
        {
            return View();
        }
    }
}