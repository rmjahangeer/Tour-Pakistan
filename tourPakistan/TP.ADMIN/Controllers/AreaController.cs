using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class AreaController : BaseController
    {
        private readonly IAreaService areaService;
        private readonly IProvinceService provinceService;

        public AreaController(IAreaService areaService, IProvinceService provinceService)
        {
            this.areaService = areaService;
            this.provinceService = provinceService;
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
            AreaViewModel viewModel = new AreaViewModel();
            if (id != null)
            {
                viewModel.Area = areaService.GetAreaById((int)id).MapFromServerToClient();
                
            }
            viewModel.ProvinceDdl =
                    provinceService.GetAllProvinces().ToList().Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddArea(AreaViewModel model)
        {
            if (model.Area.AreaId == 0)
            {
                model.Area.RecCreatedDate = DateTime.Now;
                model.Area.RecCreatedBy = Session["UserID"].ToString();
            }
            model.Area.RecLastUpdatedBy = Session["UserID"].ToString();
            model.Area.RecLastUpdatedDate = DateTime.Now;

            if (areaService.AddUpdateArea(model.Area.MapFromClientToServer()))
            {
                TempData["Message"] = new MessageViewModel { Message = "Area Added Successfully", IsSaved = true };
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
                TempData["Message"] = new MessageViewModel { Message = "Area Deleted Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something went wrong", IsError = true };
            }
            return RedirectToAction("AreaIndex");
        }
    }
}