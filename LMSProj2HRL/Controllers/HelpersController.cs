using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace LMSProj2HRL.Controllers
{
    public class HelpersController : Controller
    {
        /// <summary>
        /// Sparar filen på servern
        /// </summary>
        /// <param name="destPath">Sökväg</param>
        /// <param name="UpFile">Filnamnet som ska sparas</param>
        public void SaveFiles(string destPath, HttpPostedFileBase UpFile)
        {
            if (UpFile != null && UpFile.ContentLength > 0)
                try
                {
                    string FileHandler = "~/FileHandler/" + destPath + "/";
                    string path = Path.Combine(Server.MapPath(FileHandler), Path.GetFileName(UpFile.FileName));
                    UpFile.SaveAs(path);
                    ViewBag.Message = "Filen '" + UpFile.FileName + "' sparad";
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Error:" + e.Message.ToString() + " Filen '" + UpFile.FileName + "' har ej sparats";
                }
            else
            {
                ViewBag.Message = "Du måste ange en fil!";
            }
        }
    }
}