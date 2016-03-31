using LMSProj2HRL.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class ClassFilesController : Controller
    {
        private ItemContext db = new ItemContext();
        // GET: Common
        public ActionResult Index()
        {
            
            // SELECT Name From SchoolClasses c, Students s WHERE s.LoginId = ? AND s.SCId = c.SCId
            string path = Server.MapPath("~/FileHandler/Shared/" + System.Web.HttpContext.Current.Session["SchoolClass"].ToString());
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            return View(files);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UpFile)
        {
            if (UpFile != null && UpFile.ContentLength > 0)
                try
                {
                    string FileHandler = "~/FileHandler/" + System.Web.HttpContext.Current.Session["SchoolClass"].ToString();
                    string path = Path.Combine(Server.MapPath(FileHandler), Path.GetFileName(UpFile.FileName));
                    UpFile.SaveAs(path);
                    ViewBag.Message = "Filen sparad";
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error:" + e.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Du måste ange en fil!";
            }
            return View();
        }
    }
}