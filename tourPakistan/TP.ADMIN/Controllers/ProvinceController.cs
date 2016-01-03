using System;
using System.Linq;
using System.Web.Mvc;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class ProvinceController : BaseController
    {
        private readonly IProvinceService provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            this.provinceService = provinceService;
        }

        public ActionResult ProvinceIndex()
        {
            var listViewModel = provinceService.GetAllProvinces().Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(listViewModel);
        }

        public ActionResult AddProvince(int ? id)
        {
            var model = new ProvinceModel();
            if (id != null)
            {
                model = provinceService.GetProvinceById((int) id).MapFromServerToClient() ?? new ProvinceModel();
            }
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProvince(ProvinceModel model)
        {
            if (model.ProvinceId == 0)
            {
                model.RecCreatedDate = DateTime.Now;
                model.RecCreatedBy = Session["UserID"].ToString();
            }
            model.RecLastUpdatedBy = Session["UserID"].ToString();
            model.RecLastUpdatedDate = DateTime.Now;

            if (provinceService.AddUpdateProvince(model.MapFromClientToServer()))
            {
                TempData["Message"] = new MessageViewModel {Message = "Province Added Successfully", IsSaved = true};
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something Went wrong", IsError = true };
            }

            if (Request.Form["save"] != null)
                    return RedirectToAction("ProvinceIndex");

            return RedirectToAction("AddProvince");
        }

    }
}