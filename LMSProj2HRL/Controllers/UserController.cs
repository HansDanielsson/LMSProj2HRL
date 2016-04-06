using System.Web.Mvc;
using System.Web.Security;

namespace LMSProj2HRL.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Logga in i systemet
        /// </summary>
        /// <returns>Visar inloggningsbilden</returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Kollar upp vilken inloggning man har till LMS
        /// </summary>
        /// <param name="user">Login uppgifter</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Models.Teacher user)
        {
            if (ModelState.IsValid)
            {
                if (Helpers.IsValid.CheckIsValid(user.LoginId, user.PassWD))
                {
                    FormsAuthentication.SetAuthCookie(user.LoginId, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Felaktig inloggning!");
                }
            }
            return View(user);
        }

        /// <summary>
        /// Logga ut från LMS
        /// </summary>
        /// <returns>Till Home/Index</returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}