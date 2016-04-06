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

        // GET: Common
        /// <summary>
        /// Listar filerna på klassens gemensama ställe som finns på servern
        /// </summary>
        /// <param name="id">Klassnamnet</param>
        /// <returns></returns>
        public ActionResult Index(string id)
        {
            string path = Server.MapPath("~/FileHandler/Shared/" + id + "/");
            ViewBag.PathToClass = id;
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            return View(files);
        }
        /// <summary>
        /// Sparar en fil under gemensam katalog Shared
        /// </summary>
        /// <param name="id">Sökvägen på servern under Shared </param>
        /// <param name="UpFile">Filnamnet som ska sparas</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string id,HttpPostedFileBase UpFile)
        {
            this.SaveFiles("Shared/" + id ,UpFile);
            return RedirectToAction("Index");
        }
    }
}