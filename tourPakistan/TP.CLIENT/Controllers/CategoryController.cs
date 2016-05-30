using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

// ReSharper disable InconsistentNaming

namespace tourPakistan.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ILocationService locationService;

        public CategoryController(ICategoryService categoryService, ILocationService locationService)
        {
            this.categoryService = categoryService;
            this.locationService = locationService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var response = categoryService.GetAllCategories().Where(x=>x.IsActive).Select(x => x.MapCategoryFromServerToClient()).ToList();
            return View(response);
        }

        public ActionResult LocationDetail(int id)
        {
            var location = locationService.GetLocationByIdWithImages(id).MapLocationWithImages();
            return PartialView("_LocationDetail", location);
        }

    }
}