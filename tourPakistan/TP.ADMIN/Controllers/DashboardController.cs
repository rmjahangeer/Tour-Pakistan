using System.Web.Mvc;
using TP.Interfaces.IServices;
using TP.Models.ResponseModels;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        
        private readonly IDashboardService dashboardService;

        
        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }
        
        public ActionResult Index()
        {
            DashboardResponseModel model= dashboardService.GetDashboardData();
            return View(model);
        }

    }
}