using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class UploadController : HelpersController
    {
        // GET: Upload
        public ActionResult Index(string id)
        {
			return View();
        }
	
        [HttpPost]
        public ActionResult Index(string id, HttpPostedFileBase UpFile)
        {
            this.SaveFiles(id, UpFile); //used to be (System.Web.HttpContext.Current.Session["SchoolClass"].ToString(), UpFile);
            return View();
        }
    }
}