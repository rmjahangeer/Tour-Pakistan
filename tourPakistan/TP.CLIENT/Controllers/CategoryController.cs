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
        private static List<CategoryViewModel> response = new List<CategoryViewModel>();
        private static IEnumerable<LocationImageWebModel> images;

        public CategoryController(ICategoryService categoryService, ILocationService locationService)
        {
            this.categoryService = categoryService;
            this.locationService = locationService;
        }

        // GET: Category
        public ActionResult Index()
        {
            response = categoryService.GetAllCategories().Where(x=>x.IsActive).Select(x => x.MapCategoryFromServerToClient()).ToList();

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
            return File(new byte[20], "");

        }

        public ActionResult LocationDetail(int id)
        {
            var location = locationService.GetLocationByIdWithImages(id).MapLocationWithImages();
            images = location.LocationImages;
            return PartialView("_LocationDetail", location);
        }

        public FileResult LoadLocationImage(int id)
        {
            var image = images.SingleOrDefault(x => x.ImageId.Equals(id));
            if (image != null)
            {
                string ext = image.ContentType.Split('/')[1];

                return File(image.ImageData, image.ContentType, "IMG_" + image.ImageId + "." + ext);
            }
            return File(new byte[20], "");

        }
    }
}