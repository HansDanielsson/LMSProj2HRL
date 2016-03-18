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
                string _sql = @"SELECT [LoginId] FROM [dbo].[Teachers]" +
                       @"WHERE [LoginId] = @u AND [PassWD] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _loginId;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = _passWD;
                    //.Value = Sha1.Encode(_passWD);
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        } 
    }
}