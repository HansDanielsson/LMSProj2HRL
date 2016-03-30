﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSProj2HRL.DataAccessLayer;

namespace LMSProj2HRL.Controllers
{
    public class CommonController : Controller
    {
        private ItemContext db = new ItemContext();
        // GET: Common
        public ActionResult Index()
        {
            string path = Server.MapPath("~/FileHandler/Shared/");
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);

            // SELECT Name From SchoolClasses c, Students s WHERE s.LoginId = ? AND s.SCId = c.SCId
            string SC = System.Web.HttpContext.Current.Session["SchoolClass"].ToString();
            IEnumerable<string> ClassName = (from c in db.SchoolClass
                            where c.SCId.ToString() == SC
                            select c.Name);

            path = Server.MapPath("~/FileHandler/Shared/" + ClassName.ElementAt(0));
            dir = new DirectoryInfo(path);
            var files2 = dir.EnumerateFiles().Select(f => f.Name);
            
            for (int i = files2.Count()-1; i >= 0; i--)
            {
                //files2.ElementAt(i) = ClassName.ElementAt(0) + "/" + files2.ElementAt(i);
            }
            var files3 = files.Concat(files2);
            return View(files3);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase UpFile)
        {
            if (UpFile != null && UpFile.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/FileHandler/Shared"), Path.GetFileName(UpFile.FileName));
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