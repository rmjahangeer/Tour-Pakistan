using System;
using System.Linq;
using System.Web.Mvc;
using TP.Implementation.Services;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace TMD.Web.Controllers
{
    public class SeasonController : BaseController
    {
        private readonly ISeasonService seasonService;

        public SeasonController(ISeasonService seasonService)
        {
            this.seasonService = seasonService;
        }

        public ActionResult SeasonIndex()
        {
            var listViewModel = seasonService.GetAllSeasons().Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(listViewModel);
        }

        public ActionResult AddSeason(int? id)
        {
            var model = new SeasonModel();
            if (id != null)
            {
                model = seasonService.GetSeasonById((int)id).MapFromServerToClient() ?? new SeasonModel();
            }
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSeason(SeasonModel model)
        {
            if (model.SeasonId == 0)
            {
                model.RecCreatedDate = DateTime.Now;
                model.RecCreatedBy = Session["UserID"].ToString();
            }
            model.RecLastUpdatedBy = Session["UserID"].ToString();
            model.RecLastUpdatedDate = DateTime.Now;

            if (seasonService.AddUpdateSeason(model.MapFromClientToServer()))
            {
                TempData["Message"] = new MessageViewModel { Message = "Season Added Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something Went wrong", IsError = true };
            }

            if (Request.Form["save"] != null)
                return RedirectToAction("SeasonIndex");

            return RedirectToAction("AddSeason");
        }

    }
}