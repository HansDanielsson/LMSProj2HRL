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
    public class SchoolClassesController : Controller
    {
        private ItemContext db = new ItemContext();

        // GET: SchoolClasses
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
                db.SchoolClass.Add(schoolClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeId = new SelectList(db.Teacher, "TeId", "LoginId", schoolClass.TeId);
            ViewBag.SCId = new SelectList(db.Timetable, "TtId", "Lesson1", schoolClass.SCId);
            return View(schoolClass);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolClass schoolClass = db.SchoolClass.Find(id);
            db.SchoolClass.Remove(schoolClass);
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
