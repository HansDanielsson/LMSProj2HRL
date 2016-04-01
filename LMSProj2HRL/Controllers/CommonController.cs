using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LMSProj2HRL.Controllers
{
    public class CommonController : HelpersController
    {
        // GET: Common
        public ActionResult Index()
        {
            string path = Server.MapPath("~/FileHandler/Shared/");
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            return View(files);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UpFile)
        {
            this.SaveFiles("Shared", UpFile);
            //return View();
            return RedirectToAction("Index");
        }
    }
}