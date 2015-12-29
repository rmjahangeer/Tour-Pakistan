using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMD.Web.Controllers;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace MetronicReady.Controllers
{
    public class AreaController : BaseController
    {
        private readonly IAreaService areaService;

        public AreaController(IAreaService areaService)
        {
            this.areaService = areaService;
        }

        // GET: Area
        public ActionResult AreaIndex()
        {
            var model = areaService.GetAllAreas().ToList();
            List<AreaModel> areas;
            if (model.Count == 0)
                areas = new List<AreaModel>();

            areas = model.Select(x => x.MapFromServerToClient()).ToList();

            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(areas);
        }

        public ActionResult AddArea(long? id)
        {
            var model = new AreaModel();
            if (id != null)
            {
                model = areaService.GetAreaById((int)id).MapFromServerToClient();
            }
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddArea(AreaModel model)
        {
            if (model.AreaId == 0)
            {
                model.RecCreatedDate = DateTime.Now;
                model.RecCreatedBy = Session["UserID"].ToString();
            }
            model.RecLastUpdatedBy = Session["UserID"].ToString();
            model.RecLastUpdatedDate = DateTime.Now;

            if (areaService.AddUpdateArea(model.MapFromClientToServer()))
            {
                TempData["Message"] = new MessageViewModel { Message = "Category Added Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something Went wrong", IsError = true };
            }

            if (Request.Form["save"] != null)
                return RedirectToAction("AreaIndex");

            return RedirectToAction("AddArea");
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = areaService.DeleteArea(id);
            if (isDeleted)
            {
                TempData["Message"] = new MessageViewModel { Message = "Category Deleted Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something went wrong", IsError = true };
            }
            return RedirectToAction("AreaIndex");
        }
    }
}