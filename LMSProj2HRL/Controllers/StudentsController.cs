using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LMSProj2HRL.DataAccessLayer;
using LMSProj2HRL.Models;

namespace LMSProj2HRL.Controllers
{
    public class StudentsController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: Students
        /// <summary>
        /// Listar studenter och till vilken klass hen tillhör
        /// </summary>
        /// <returns>Listan av studenter och klass</returns>
        public ActionResult Index()
        {
            var student = db.Student.Include(s => s.SchoolClass);
            return View(student.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.SCId = new SelectList(db.SchoolClass, "SCId", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Sparar en ny student, kollar om dublett finns innan.
        /// Kodar lösenordet till Sha1
        /// </summary>
        /// <param name="student">Student information</param>
        /// <returns>Index vy om ok, tillbaka om fel</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StId,LoginId,FName,SName,PassWD,SCId")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (db.Student.Where(s => s.LoginId == student.LoginId).Count() > 0)
				{
					return RedirectToAction("Message"); //ej dubletter
				}
                student.PassWD = Helpers.Sha1.Encode(student.PassWD);
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SCId = new SelectList(db.SchoolClass, "SCId", "Name", student.SCId);
            return View(student);
        }

		public ActionResult Message()
		{
			ViewBag.Message = "Det går ej att ha dubbletter!";
			return PartialView();
		}

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SCId = new SelectList(db.SchoolClass, "SCId", "Name", student.SCId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Editerar en student och lagrar med lösenord i Sha1
        /// </summary>
        /// <param name="student">Data om en student</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StId,LoginId,FName,SName,PassWD,SCId")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.PassWD = Helpers.Sha1.Encode(student.PassWD);
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SCId = new SelectList(db.SchoolClass, "SCId", "Name", student.SCId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}