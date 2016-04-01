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

        // GET´: TeacherFiles/ListClases/TeId
        public ActionResult ListClases(int? TeId)
        {
            if (TeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<string> schoolClass = from s in db.SchoolClass where (s.TeId == TeId) select s.Name;
            return View(schoolClass);
        }
    }
}