using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSProj2HRL.DataAccessLayer;
using LMSProj2HRL.Models;

namespace LMSProj2HRL.Controllers
{
    public class TimetablesController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: Timetables
        public ActionResult Index()
        {
            var timetable = db.Timetable.Include(t => t.SchoolClass);
            return View(timetable.ToList());
        }

        // GET: Timetables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: Timetables/Create
        public ActionResult Create()
        {
            ViewBag.TtId = new SelectList(db.SchoolClass, "SCId", "Name");
            return View();
        }

        // POST: Timetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TtId,DateTime,Lesson1,Lesson2,Lesson3,Lesson4")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Timetable.Add(timetable);
				try
				{
					db.SaveChanges();
				}
				catch (Exception e)
				{
                    ViewBag.Message = e.Message;
					return RedirectToAction("Message");	//inga dubbletter
				}
                return RedirectToAction("Index");
            }

            ViewBag.TtId = new SelectList(db.SchoolClass, "SCId", "Name", timetable.TtId);
            return View(timetable);
        }

		public ActionResult Message()
		{
			ViewBag.Message = "Det går ej att ha dubbletter!";
			return PartialView();
		}

        // GET: Timetables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.TtId = new SelectList(db.SchoolClass, "SCId", "Name", timetable.TtId);
            return View(timetable);
        }

        // POST: Timetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TtId,DateTime,Lesson1,Lesson2,Lesson3,Lesson4")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TtId = new SelectList(db.SchoolClass, "SCId", "Name", timetable.TtId);
            return View(timetable);
        }

        // GET: Timetables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = db.Timetable.Find(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timetable timetable = db.Timetable.Find(id);
            db.Timetable.Remove(timetable);
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
