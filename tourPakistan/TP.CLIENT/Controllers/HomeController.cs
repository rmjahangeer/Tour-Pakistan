using System.Linq;
using System.Web.Mvc;
using TP.Interfaces.IServices;
using TP.Models.ModelMapers;
using TP.Models.WebViewModels;

namespace tourPakistan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IEventService eventService;

        public HomeController(ILocationService locationService, IEventService eventService)
        {
            _locationService = locationService;
            this.eventService = eventService;
        }

        public ActionResult Index()
        {
            var recentLocations = _locationService.GetAllLocations().OrderBy(x=>x.RecCreatedDate).Take(8).Select(x=>x.MapFromServerToClient()).ToList();
            var latestEvents = eventService.GetAllEvents().OrderByDescending(x=>x.RecCreatedDate).Take(2).Select(x=>x.MapFromServerToClient()).ToList();
            HomeViewModel viewModel = new HomeViewModel
            {
                Locations = recentLocations,
                Events = latestEvents
            };
            return View(viewModel);
        }
        
        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var latestEvents = eventService.GetAllEvents().OrderByDescending(x => x.RecCreatedDate).Take(3).Select(x => x.MapFromServerToClient()).ToList();
            return View(latestEvents);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}