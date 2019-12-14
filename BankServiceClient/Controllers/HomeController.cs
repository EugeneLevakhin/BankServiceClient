using System.Web.Mvc;

namespace BankServiceClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("About");
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }
    }
}