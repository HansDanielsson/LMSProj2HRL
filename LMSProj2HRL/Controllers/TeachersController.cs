using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LMSProj2HRL.DataAccessLayer;
using LMSProj2HRL.Models;

namespace LMSProj2HRL.Controllers
{
	public class TeachersController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: Teachers
		/// <summary>
		/// Listar alla lärare
		/// </summary>
		/// <returns>Lista med lärare</returns>
        public ActionResult Index()
        {
            return View(db.Teacher.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacher.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeId,LoginId,FName,SName,PassWD")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
				int totsum = db.Teacher.Where(s => s.LoginId == teacher.LoginId).Count();
				if (totsum > 0)			//om ej noll då finns redan läraren
				{
					return RedirectToAction("Message"); //Dubletter ej tillåtet
				}

                teacher.PassWD = Helpers.Sha1.Encode(teacher.PassWD);
                db.Teacher.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

		public ActionResult Message()
		{
			ViewBag.Message = "Det går ej att ha dubbletter!";
			return PartialView();
		}

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacher.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeId,LoginId,FName,SName,PassWD")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.PassWD = Helpers.Sha1.Encode(teacher.PassWD);
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teacher.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teacher.Find(id);
            db.Teacher.Remove(teacher);
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
