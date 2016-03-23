﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            var path = Server.MapPath("~/FileHandler/");
            var dir = new DirectoryInfo(path);
            var files = dir.EnumerateFiles().Select(f => f.Name);
            return View(files);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase ValFilen)
        {
            if (ValFilen != null && ValFilen.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/FileHandler"), Path.GetFileName(ValFilen.FileName));
                    ValFilen.SaveAs(path);
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