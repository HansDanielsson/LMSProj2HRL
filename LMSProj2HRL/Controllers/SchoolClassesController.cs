using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LMSProj2HRL.DataAccessLayer;
using LMSProj2HRL.Models;


namespace LMSProj2HRL.Controllers
{
	public class SchoolClassesController : Controller
	{
		private ItemContext db = new ItemContext();

		// GET: SchoolClasses
        /// <summary>
        /// Listar alla skolklasser som har en lärare och ibland schema
        /// </summary>
        /// <returns>Visar en lista på skolklasser</returns>
		public ActionResult Index()
		{
			var schoolClass = db.SchoolClass.Include(s => s.Teacher).Include(s => s.Timetable);
			return View(schoolClass.ToList());
		}

		// GET: SchoolClasses/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SchoolClass schoolClass = db.SchoolClass.Find(id);
			if (schoolClass == null)
			{
				return HttpNotFound();
			}
			return View(schoolClass);
		}

		// GET: SchoolClasses/Create
		public ActionResult Create()
		{
			ViewBag.TeId = new SelectList(db.Teacher, "TeId", "LoginId");
			ViewBag.SCId = new SelectList(db.Timetable, "TtId", "Lesson1");
			return View();
		}

		// POST: SchoolClasses/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "SCId,Name,TeId")] SchoolClass schoolClass)
		{
			if (ModelState.IsValid)
			{
				int totsum = db.SchoolClass.Where(s => s.Name == schoolClass.Name).Count();
				if (totsum > 0)
				{
					return RedirectToAction("Message"); //ej dubletter
				}

				string path = Server.MapPath("~/FileHandler/" + schoolClass.Name);
				if (!Directory.Exists(path))
				{
					DirectoryInfo di = Directory.CreateDirectory(path);

					path = Server.MapPath("~/FileHandler/Shared/" + schoolClass.Name);
					if (!Directory.Exists(path))
					{
						di = Directory.CreateDirectory(path);
					}
				}

				db.SchoolClass.Add(schoolClass);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.TeId = new SelectList(db.Teacher, "TeId", "LoginId", schoolClass.TeId);
			ViewBag.SCId = new SelectList(db.Timetable, "TtId", "Lesson1", schoolClass.SCId);
			return View(schoolClass);
		}

		public ActionResult Message()
		{
			ViewBag.Message = "Det går ej att ha dubbletter!";
			return PartialView();
		}

		// GET: SchoolClasses/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SchoolClass schoolClass = db.SchoolClass.Find(id);
			if (schoolClass == null)
			{
				return HttpNotFound();
			}
			ViewBag.TeId = new SelectList(db.Teacher, "TeId", "LoginId", schoolClass.TeId);
			ViewBag.SCId = new SelectList(db.Timetable, "TtId", "Lesson1", schoolClass.SCId);
			return View(schoolClass);
		}

		// POST: SchoolClasses/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "SCId,Name,TeId")] SchoolClass schoolClass)
		{
			if (ModelState.IsValid)
			{
				db.Entry(schoolClass).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.TeId = new SelectList(db.Teacher, "TeId", "LoginId", schoolClass.TeId);
			ViewBag.SCId = new SelectList(db.Timetable, "TtId", "Lesson1", schoolClass.SCId);
			return View(schoolClass);
		}

		// GET: SchoolClasses/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SchoolClass schoolClass = db.SchoolClass.Find(id);
			if (schoolClass == null)
			{
				return HttpNotFound();
			}
			return View(schoolClass);
		}

		// POST: SchoolClasses/Delete/5
        /// <summary>
        /// Tar bort en klass, kollar att schemat tas bort samt kataloger och filer till klassen
        /// </summary>
        /// <param name="id">Index id till klassen</param>
        /// <returns></returns>
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			SchoolClass schoolClass = db.SchoolClass.Find(id);

			int totsum = db.Timetable.Where(t => t.TtId == schoolClass.SCId).Count();
			if (totsum > 0)
			{
				Timetable timetable = db.Timetable.Find(schoolClass.SCId);
				db.Timetable.Remove(timetable);
			}

			db.SchoolClass.Remove(schoolClass);
			db.SaveChanges();

			string path = Server.MapPath("~/FileHandler/" + schoolClass.Name);
			if (Directory.Exists(path))
			{
				Directory.Delete(path, true);
			}

			path = Server.MapPath("~/FileHandler/Shared/" + schoolClass.Name);
			if (Directory.Exists(path))
			{
				Directory.Delete(path, true);
			}
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