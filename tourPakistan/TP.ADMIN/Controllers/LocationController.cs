using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Models.ModelMappers;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class LocationController : BaseController
    {
        private readonly ILocationService locationService;
        private readonly IProvinceService provinceService;
        private readonly IAreaService areaService;
        private readonly ICategoryService categoryService;
        private readonly ILocationImageService locationImageService;
        private static List<LocationImageWebModel> locationImagesList = new List<LocationImageWebModel>();

        public LocationController(ILocationService locationService, IProvinceService provinceService, IAreaService areaService, ICategoryService categoryService, ILocationImageService locationImageService)
        {
            this.locationService = locationService;
            this.provinceService = provinceService;
            this.areaService = areaService;
            this.categoryService = categoryService;
            this.locationImageService = locationImageService;
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

            var savedLocationId = locationService.AddUpdateLocations(model.Location.MapFromClientToServer());
            if (savedLocationId > 0)
            {
                TempData["Message"] = new MessageViewModel { Message = "Location Added Successfully", IsSaved = true };
                AddLocationImages(savedLocationId);
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

        [HttpPost]
        public JsonResult DeleteImage(long id)
        {
            if (locationImageService.DeleteLocationImage(id))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Images(long id)
        {
            locationImagesList = locationImageService.GetAllLocationImages(id).ToList().Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.LocationId = id;
            return View(locationImagesList);
        }

        public FileResult GetImage(long id)
        {
            var image = locationImagesList.SingleOrDefault(x => x.ImageId == id);
            if (image != null)
            {
                string ext = image.ContentType.Split('/')[1];

                return File(image.ImageData, image.ContentType, "IMG_" + image.ImageId + image.IsActive + "." + ext);   
            }
            return File(new byte[20], "");

        }

        #region Helpers
        private void AddLocationImages(long id)
        {
            var imageWebModel = new List<LocationImageWebModel>(Request.Files.Count);

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    imageWebModel.Add(new LocationImageWebModel()
                    {
                        IsActive = true,
                        RecCreatedBy = User.Identity.GetUserId(),
                        RecCreatedDate = DateTime.Now,
                        RecLastUpdatedBy = User.Identity.GetUserId(),
                        RecLastUpdatedDate = DateTime.Now,
                        LocationId = id,
                        Image = file
                    });
                    SaveImage(imageWebModel[i]);
                }
            }
            locationImageService.AddUpdateLocationImages(imageWebModel);

        }
        private bool SaveImage(LocationImageWebModel location)
        {
            
            var tempStream = location.Image.InputStream;

            //File size must be less than 4MBs
            if (location.Image.ContentLength > 0 && location.Image.ContentLength < 4194304)
            {
                var width = Image.FromStream(tempStream).Width;
                var height = Image.FromStream(tempStream).Height;

                Image newImage = new Bitmap(width, height);
                using (Graphics graphicsHandle = Graphics.FromImage(newImage))
                {
                    graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphicsHandle.DrawImage(Image.FromStream(tempStream), 0, 0, width, height);
                }
                //return newImage;
                var stream = new MemoryStream();
                newImage.Save(stream, GetImageFormat(location.Image.ContentType));
                stream.Position = 0;

                byte[] bytes = new byte[stream.Length];
                //copy file content to array
                stream.Read(bytes, 0, Convert.ToInt32(stream.Length));

                location.ImageData = bytes;
                location.ContentType = location.Image.ContentType;
                return true;
            }
            return false;
        }

        private ImageFormat GetImageFormat(string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return ImageFormat.Png;
            }
            contentType = contentType.Split('/')[1].ToLower();
            switch (contentType)
            {
                case "png":
                    return ImageFormat.Png;
                case "gif":
                    return ImageFormat.Gif;
                case "jpeg":
                    return ImageFormat.Jpeg;
                case "jpg":
                    return ImageFormat.Jpeg;
                default:
                    return ImageFormat.Png;
            }
        }
        #endregion
    }
}