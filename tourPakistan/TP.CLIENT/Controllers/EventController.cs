using System.Linq;
using System.Web.Mvc;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;

namespace tourPakistan.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: AddEvent
        public ActionResult Index()
        {
            var events = _eventService.GetAllEvents().ToList().Select(x => x.MapFromServerToClient()).ToList();
            return View(events);
        }
    }
}