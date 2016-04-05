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
    }
}