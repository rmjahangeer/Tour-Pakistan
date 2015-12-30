using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.ModelMappers;
using TMD.Web.Controllers;
using TP.Interfaces.IServices;
using TP.Models.DomainModels;
using TP.Models.ModelMapers;
using TP.Models.WebModels;
using TP.Models.WebViewModels;

namespace MetronicReady.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        // GET: Event
        public ActionResult EventIndex()
        {
            var model = eventService.GetAllEvents().ToList();
            List<EventModel> events;
            if (model.Count == 0)
                events = new List<EventModel>();

            events = model.Select(x => x.MapFromServerToClient()).ToList();
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(events);
        }


        public ActionResult AddEvent(long? id)
        {
            var model = new EventModel();
            if (id != null)
            {
                model = eventService.GetEventById((int)id).MapFromServerToClient();
            }
            ViewBag.MessageVM = TempData["Message"] as MessageViewModel;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEvent(EventModel model)
        {
            if (model.EventId == 0)
            {
                model.RecCreatedDate = DateTime.Now;
                model.RecCreatedBy = Session["UserID"].ToString();
            }
            model.RecLastUpdatedBy = Session["UserID"].ToString();
            model.RecLastUpdatedDate = DateTime.Now;

            if (eventService.AddUpdateEvents(model.MapFromClientToServer()))
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
    }
}