using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
            using (var cn = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnet-LMSProj2HRL-20160316022928.mdf;Initial Catalog=aspnet-LMSProj2HRL-20160316022928;Integrated Security=True"))
            {
                string _sql1 = @"SELECT LoginId FROM Teachers WHERE LoginId = @u AND PassWD = @p";
                var cmd1 = new SqlCommand(_sql1, cn);
                cmd1.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _loginId;
                cmd1.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = Sha1.Encode(_passWD);
                cn.Open();
                var reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    HttpContext.Current.Session["UserLMS"] = 1;
                    // Sätt global variabel till Teachers status
                    reader1.Dispose();
                    cmd1.Dispose();
                    return true;
                }
                else
                {
                    cn.Close();
                    string _sql2 = @"SELECT LoginId FROM Students WHERE LoginId = @u AND PassWD = @p";
                    var cmd2 = new SqlCommand(_sql2, cn);
                    cmd2.Parameters
                        .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                        .Value = _loginId;
                    cmd2.Parameters
                        .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                        .Value = Sha1.Encode(_passWD);
                    cn.Open();
                    var reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        HttpContext.Current.Session["UserLMS"] = 2;
                        // Sätt global variabel till Students status
                        reader2.Dispose();
                        cmd2.Dispose();
                        return true;
                    }
                    else
                    {
                        reader2.Dispose();
                        cmd2.Dispose();
                        return false;
                    }
                }
            }
        }
    }
}