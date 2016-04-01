using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSProj2HRL.DataAccessLayer;

namespace LMSProj2HRL.Controllers
{
    public class TeacherFilesController : Controller
    {

        private ItemContext db = new ItemContext();

        // GET: TeacherFiles
        public ActionResult Index()
        {
            //IEnumerable<string> schoolClass = from s in db.SchoolClass where (s.TeId == HttpContext.Current.Session["SchoolClass"]) select s.Name;
           
            return View();
        }

        // GET´: TeacherFiles/ListClases/5
        public ActionResult ListClases(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<string> schoolClass = from s in db.SchoolClass where (s.TeId == id) select s.Name;
            return View(schoolClass);
        }

        // GET´: TeacherFiles/ListClases/5
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