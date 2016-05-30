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

        public HomeController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public ActionResult Index()
        {
            var recentLocations = _locationService.GetAllLocations().OrderBy(x=>x.RecCreatedDate).Take(8).Select(x=>x.MapFromServerToClient()).ToList();
            HomeViewModel viewModel = new HomeViewModel
            {
                Locations = recentLocations
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

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}