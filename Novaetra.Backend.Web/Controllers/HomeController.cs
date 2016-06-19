using System.Web.Mvc;

namespace Novaetra.Backend.Web.Controllers
{
    public class HomeController : BackendControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}