using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Det perfekta systemet...";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta:";

            return View();
        }
    }
}