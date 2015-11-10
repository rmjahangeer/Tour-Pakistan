using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tourPakistan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Search()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Category()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Features()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Single()
        {
            return View();
        }
    }
}