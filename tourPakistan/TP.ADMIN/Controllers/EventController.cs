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
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class EventController : BaseController
    {
        private readonly IEventService eventService;
        private readonly ILocationService locationService;
        private static IEnumerable<LocationModel> locationsList;
        public EventController(IEventService eventService, ILocationService locationService)
        {
            this.eventService = eventService;
            this.locationService = locationService;
        }

        // GET: Event
        public ActionResult EventIndex()
        {
            var model = eventService.GetAllEvents().ToList();

            var events = model.Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(events);
        }


        public ActionResult AddEvent(long? id)
        {
            var model = new EventViewModel();
            if (id != null)
            {
                model.Event = eventService.GetEventById(id.Value).MapFromServerToClient();
            }
            locationsList = model.Locations = locationService.GetAllLocations().Select(x => x.MapFromServerToClient());
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEvent(EventViewModel model)
        {
            if (model.Event.EventId == 0)
            {
                model.Event.RecCreatedDate = DateTime.Now;
                model.Event.RecCreatedBy = Session["UserID"].ToString();
            }
            model.Event.RecLastUpdatedBy = Session["UserID"].ToString();
            model.Event.RecLastUpdatedDate = DateTime.Now;

            if (eventService.AddUpdateEvents(model.Event.MapFromClientToServer()))
            {
                TempData["Message"] = new MessageViewModel { Message = "Event Added Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something Went wrong", IsError = true };
            }

            if (Request.Form["save"] != null)
                return RedirectToAction("EventIndex");

            return RedirectToAction("AddEvent");
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = eventService.DeleteEvent(id);
            if (isDeleted)
            {
                TempData["Message"] = new MessageViewModel { Message = "Event Deleted Successfully", IsSaved = true };
            }
            else
            {
                TempData["Message"] = new MessageViewModel { Message = "Something went wrong", IsError = true };
            }
            return RedirectToAction("EventIndex");
        }

        public FileResult GetImage(long id)
        {
            var image = locationsList.Single(x => x.LocationId == id).LocationImage;
            if (image != null)
            {
                string ext = image.ContentType.Split('/')[1];

                return File(image.ImageData, image.ContentType, "IMG_" + image.ImageId + image.IsActive + "." + ext);
            }
            return File(new byte[20], "");

        }

        
    }
}