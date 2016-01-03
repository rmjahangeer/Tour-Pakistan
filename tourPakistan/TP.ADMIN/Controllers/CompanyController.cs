using System.Web.Mvc;

namespace TMD.Web.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
    }
}