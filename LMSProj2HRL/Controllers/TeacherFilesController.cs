using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSProj2HRL.DataAccessLayer;

namespace LMSProj2HRL.Controllers
{
    public class TeacherFilesController : HelpersController
    {

        private ItemContext db = new ItemContext();

        // GET: TeacherFiles
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Hur fixar man till en ny parameter?
        /// </summary>
        /// <param name="UpFile"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UpFile)
        {
            string path = "Shared/Mt1A";
            this.SaveFiles(path, UpFile);
            return View();
        }

        // GET´: TeacherFiles/ListClases
        public ActionResult ListClases(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<string> schoolClass = from s in db.SchoolClass where (s.TeId == id) select s.Name;
            return View(schoolClass);
        }

        // GET´: TeacherFiles/ListSharedClases/5
        public ActionResult ListSharedClases(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<string> schoolClass = from s in db.SchoolClass where (s.TeId == id) select s.Name;
            return View(schoolClass);
        }

        // GET´: TeacherFiles/ListClases/KlassName
        public ActionResult ListTeacherFiles(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string path = Server.MapPath("~/FileHandler/" + id + "/");
            var dir = new DirectoryInfo(path);
            IEnumerable<string> files = dir.EnumerateFiles().Select(f => f.Name);
            List<string> files2 = new List<string>();
            for (int i = 0 ; i < files.Count(); i++)
            {
                files2.Add(id + "/" + files.ElementAt(i));
            }
            return View(files2);
        }
    }
}