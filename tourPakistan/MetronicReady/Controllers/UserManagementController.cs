﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetronicReady.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult user()
        {
            return View();
        }

        public ActionResult company()
        {
            return View();
        }
    }
}