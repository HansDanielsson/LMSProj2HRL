using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LMSProj2HRL.Controllers
{
    public class CommonController : HelpersController
    {
        // GET: Common
        /// <summary>
        /// Listar filer under gemensam katalog Shared
        /// </summary>
        /// <returns>Visar listan på filer</returns>
        public ActionResult Index()
        {
            string path = Server.MapPath("~/FileHandler/Shared/");
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            return View(files);
        }

        /// <summary>
        /// Spara en fil under Shared
        /// </summary>
        /// <param name="UpFile">Filnamnet som ska sparas</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UpFile)
        {
            this.SaveFiles("Shared", UpFile);
            return RedirectToAction("Index");
        }
    }
}