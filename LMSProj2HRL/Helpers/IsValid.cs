﻿using System.Collections.Generic;
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
            _passWD = Sha1.Encode(_passWD);
            IEnumerable<int> Teacher = from t in db.Teacher where (t.LoginId == _loginId) && (t.PassWD == _passWD) select t.TeId;
            if (Teacher.Count() == 1)
            {
                // Sätt global variabel till Teachers status
                HttpContext.Current.Session["UserLMS"] = 1;
                HttpContext.Current.Session["SchoolClass"] = Teacher.ElementAt(0);
                return true;
            }
            else
            {
                //SELECT Name FROM SchoolClasses c
                //            JOIN Students s
                //            WHERE c.SCId = s.SCId AND LoginId = _loginId AND PassWD = _passWD;
                //
                IEnumerable<string> Student = from c in db.SchoolClass
                                              join s in db.Student
                                              on c.SCId equals s.SCId
                                              where ((s.LoginId == _loginId) && (s.PassWD == _passWD))
                                              select c.Name;
                                             
                if (Student.Count() == 1)
                {
                    // Sätt global variabel till Students status
                    HttpContext.Current.Session["UserLMS"] = 2;
                    HttpContext.Current.Session["SchoolClass"] = Student.ElementAt(0);
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