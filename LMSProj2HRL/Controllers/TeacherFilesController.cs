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

        // GET : TeacherFiles/ListClases
		/// <summary>
		/// Listar inlämningsuppgifter per klass och klasslärare
		/// </summary>
		/// <param name="id">lärarens id</param>
		/// <returns>listar filer som är elevers inlämningsuppgifter</returns>
        public ActionResult ListClases(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<string> schoolClass = from s in db.SchoolClass where (s.TeId == id) select s.Name;
            return View(schoolClass);
        }

        // GET: TeacherFiles/ListSharedClases/5
		/// <summary>
		/// Listar dokument som är gemensamma för alla klasser och alla lärare och elever
		/// </summary>
		/// <param name="id">lärarens id</param>
		/// <returns>lista på filerna som är under Gemensamma-Filer</returns>
        public ActionResult ListSharedClases(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<string> schoolClass = from s in db.SchoolClass where (s.TeId == id) select s.Name;
            return View(schoolClass);
        }
    }
}