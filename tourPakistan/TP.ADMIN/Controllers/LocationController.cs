using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ModelMappers;
using TMD.Web;
using TMD.Web.Controllers;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace MetronicReady.Controllers
{
    public class LocationController : BaseController
    {
        private readonly ILocationService locationService;
        private readonly IProvinceService provinceService;
        private readonly IAreaService areaService;
        private readonly ICategoryService categoryService;

        public LocationController(ILocationService locationService, IProvinceService provinceService, IAreaService areaService, ICategoryService categoryService)
        {
            this.locationService = locationService;
            this.provinceService = provinceService;
            this.areaService = areaService;
            this.categoryService = categoryService;
        }

        // GET: Location
        public ActionResult LocationIndex()
        {
            var model = locationService.GetAllLocations().ToList();
            List<LocationModel> locations;
            if (model.Count == 0)
                locations = new List<LocationModel>();

            locations = model.Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(locations);
        }


        public ActionResult AddLocation(long? id)
        {
            LocationViewModel viewModel = new LocationViewModel();
            
            if (id != null)
            {
                viewModel.Location = locationService.GetLocationById((int)id).MapFromServerToClient();
            }
            viewModel.ProvinceDdl = provinceService.GetAllProvinces().ToList().Select(x => x.MapFromServerToClient()).ToList();
            viewModel.AreaDdl = areaService.GetAllAreas().ToList().Select(x => x.MapFromServerToClient()).ToList();
            viewModel.CategoryDdl = categoryService.GetAllCategories().ToList().Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddLocation(LocationViewModel model)
        {
            if (model.Location.LocationId == 0)
            {
                model.Location.RecCreatedDate = DateTime.Now;
                model.Location.RecCreatedBy = Session["UserID"].ToString();
            }
            model.Location.RecLastUpdatedBy = Session["UserID"].ToString();
            model.Location.RecLastUpdatedDate = DateTime.Now;

            if (locationService.AddUpdateLocations(model.Location.MapFromClientToServer()))
            {
                TempData["Message"] = new MessageViewModel { Message = "Location Added Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something Went wrong", IsError = true };
            }

            if (Request.Form["save"] != null)
                return RedirectToAction("LocationIndex");

            return RedirectToAction("AddLocation");
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = locationService.DeleteLocation(id);
            if (isDeleted)
            {
                TempData["Message"] = new MessageViewModel { Message = "Location Deleted Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something went wrong", IsError = true };
            }
            return RedirectToAction("LocationIndex");
        }


        #region Helpers

        //public FileResult LoadSliderImage(long id)
        //{
        //    //pass id to service, and load image data
        //    var image = webSiteSliderService.GetSlide(id);

        //    string ext = image.ImageType.Split('/')[1];
        //    return File(image.ImageData, image.ImageType, "IMG_" + image.SlideId + ((DateTime)image.RecLastUpdatedDate).ToString("yyyyMMdd_HHmmss") + "." + ext);
        //}

        //private bool SaveProductImage(WebSiteSliderWebModel webSiteSliderWebModel)
        //{
        //    var tempStream = webSiteSliderWebModel.SliderImage.InputStream;

        //    //File size must be less than 2MBs
        //    if (webSiteSliderWebModel.SliderImage.ContentLength > 0 &&
        //        webSiteSliderWebModel.SliderImage.ContentLength < 2000000)
        //    {
        //        //reisze the image for facebook optimization
        //        var resizedImage = Utility.ResizeImage(Image.FromStream(tempStream),
        //            Utility.GetImageFormat(webSiteSliderWebModel.SliderImage.ContentType),
        //            Convert.ToInt32(ConfigurationManager.AppSettings["ProductImageWidth"]),
        //            Convert.ToInt32(ConfigurationManager.AppSettings["ProductImageHeight"]), true);

        //        byte[] bytes = new byte[resizedImage.Length];
        //        //copy file content to array
        //        resizedImage.Read(bytes, 0, Convert.ToInt32(resizedImage.Length));

        //        webSiteSliderWebModel.ImageData = bytes;
        //        webSiteSliderWebModel.ImageType = webSiteSliderWebModel.SliderImage.ContentType;
        //        return true;
        //    }
        //    return false;
        //}
        #endregion
    }
}