using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class UploadController : HelpersController
    {
        // GET: Upload
        public ActionResult Index()
        {
			return View();
        }
	
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UpFile)
        {
            this.SaveFiles(System.Web.HttpContext.Current.Session["SchoolClass"].ToString(), UpFile);
            //if (UpFile != null && UpFile.ContentLength > 0)
            //    try
            //    {
            //        string FileHandler = "~/FileHandler/" + System.Web.HttpContext.Current.Session["SchoolClass"].ToString();
            //        string path = Path.Combine(Server.MapPath(FileHandler), Path.GetFileName(UpFile.FileName));
            //        UpFile.SaveAs(path);
            //        ViewBag.Message = "Filen '" + UpFile.FileName + "' sparad";
            //    }
            //    catch (Exception e)
            //    {
            //        ViewBag.Message = "Error:" + e.Message.ToString() + " Filen '" + UpFile.FileName + "' har ej sparats";
            //    }
            //else
            //{
            //    ViewBag.Message = "Du måste ange en fil!";
            //}
            return View();
        }
    }
}