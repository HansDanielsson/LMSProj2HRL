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
            return View();
        }
    }
}