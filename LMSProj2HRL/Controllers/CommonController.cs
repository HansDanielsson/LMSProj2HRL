using LMSProj2HRL.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LMSProj2HRL.Controllers
{
    public class CommonController : HelpersController
    {
        private ItemContext db = new ItemContext();
        // GET: Common
        public ActionResult Index()
        {
            string path = Server.MapPath("~/FileHandler/Shared/");
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            return View(files);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UpFile)
        {
            this.SaveFiles("Shared", UpFile);
            return View();
        }
    }
}