using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class UploadController : HelpersController
    {
        // GET: Upload
        public ActionResult Index(string id)
        {
            string path = Server.MapPath("~/FileHandler/" + id + "/");
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
			return View(files);
        }
	
        [HttpPost]
        public ActionResult Index(string id, HttpPostedFileBase UpFile)
        {
            this.SaveFiles(id, UpFile); //used to be (System.Web.HttpContext.Current.Session["SchoolClass"].ToString(), UpFile);
            return View();
        }
    }
}