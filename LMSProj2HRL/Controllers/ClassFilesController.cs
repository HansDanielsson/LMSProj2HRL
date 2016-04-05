using LMSProj2HRL.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class ClassFilesController : HelpersController
    {
        //private ItemContext db = new ItemContext();
        // GET: Common
        public ActionResult Index(string id)
        {
            string path = Server.MapPath("~/FileHandler/Shared/" + id + "/");
            ViewBag.PathToClass = id;
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            return View(files);
        }

        [HttpPost]
        public ActionResult Index(string id,HttpPostedFileBase UpFile)
        {
            this.SaveFiles("Shared/" + id ,UpFile);
            return RedirectToAction("Index");
        }
    }
}