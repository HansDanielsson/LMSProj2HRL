using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class UploadController : HelpersController
    {
        // GET: Upload
        /// <summary>
        /// Listar filer under en klass katalog
        /// </summary>
        /// <param name="id">Klass namn</param>
        /// <returns></returns>
        public ActionResult Index(string id)
        {
            string path = Server.MapPath("~/FileHandler/" + id + "/");
            ViewBag.PathToClass = id;
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
			return View(files);
        }
	
        /// <summary>
        /// Sparar en fil under klassens katalog
        /// </summary>
        /// <param name="id">Klass namn</param>
        /// <param name="UpFile">Filen som ska sparas</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string id, HttpPostedFileBase UpFile)
        {
            this.SaveFiles(id, UpFile);
            return View();
        }
    }
}