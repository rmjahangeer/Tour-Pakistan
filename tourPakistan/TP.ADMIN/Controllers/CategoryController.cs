using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ModelMappers;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace MetronicReady.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICateogryService cateogryService;

        public CategoryController(ICateogryService cateogryService)
        {
            this.cateogryService = cateogryService;
        }

        // GET: Category
        public ActionResult CategoryIndex()
        {
            return View();
        }


        public ActionResult AddCategory(long ? id)
        {
            var model = new CategoryModel();
            if (id != null)
            {
                model = cateogryService.GetCategoryById((int) id).MapFromServerToClient();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            if (model.CategoryId == 0)
            {
                model.RecCreatedDate = DateTime.Now;
                model.RecCreatedBy = Session["UserID"].ToString();
            }
            model.RecLastUpdatedBy = Session["UserID"].ToString();
            model.RecLastUpdatedDate = DateTime.Now;

            if (cateogryService.AddUpdateCategory(model.MapFromClinetToServer()))
            {
                TempData["Message"] = new MessageViewModel { Message = "Category Added Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something Went wrong", IsError = true };
            }

            if (Request.Form["save"] != null)
                return RedirectToAction("CategoryIndex");

            return RedirectToAction("AddCategory");
        }
    }
}