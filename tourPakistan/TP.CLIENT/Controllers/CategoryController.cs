using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Models.ModelMappers;
using TP.Interfaces.IServices;
using TP.Models.WebViewModels;

// ReSharper disable InconsistentNaming

namespace tourPakistan.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private static List<CategoryViewModel> response = new List<CategoryViewModel>();

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            response = categoryService.GetAllCategories().Select(x => x.MapCategoryFromServerToClient()).ToList();

            return View(response);
        }

        public FileResult GetImage(long categoryId, long locationId)
        {
            var image = response.SingleOrDefault(x => x.CategoryId == categoryId).Locations.SingleOrDefault(x=>x.LocationId == locationId).LocationImage;
            if (image != null)
            {
                string ext = image.ContentType.Split('/')[1];

                return File(image.ImageData, image.ContentType, "IMG_" + image.ImageId + image.IsActive + "." + ext);
            }
            return File(new byte[20], "image/jpeg", "raw image");

        }
    }
}