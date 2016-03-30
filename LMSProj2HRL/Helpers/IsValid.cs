using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LMSProj2HRL.DataAccessLayer;
namespace LMSProj2HRL.Helpers
{
    public class IsValid
    {

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public static bool CheckIsValid(string _loginId, string _passWD)
        {
            ItemContext db = new ItemContext();
            _passWD = Helpers.Sha1.Encode(_passWD);
            var Teacher = from t in db.Teacher where (t.LoginId == _loginId) && (t.PassWD == _passWD) select t;
            if (Teacher.Count() == 1)
            {
                HttpContext.Current.Session["UserLMS"] = 1;
                HttpContext.Current.Session["UserName"] = _loginId;
                // Sätt global variabel till Teachers status
                return true;
            }
            else
            {
                var Student = from s in db.Student where (s.LoginId == _loginId) && (s.PassWD == _passWD) select s;
                if (Student.Count() == 1)
                {
                    HttpContext.Current.Session["UserLMS"] = 2;
                    HttpContext.Current.Session["UserName"] = _loginId;
                    HttpContext.Current.Session["SchoolClass"] = Student;
                    // Sätt global variabel till Students status
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}