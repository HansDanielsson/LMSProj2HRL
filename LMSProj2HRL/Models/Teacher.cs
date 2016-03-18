using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMSProj2HRL.Models
{
    public class Teacher
    {
        [Key]
        public int TeId { get; set; }

        [Required]
        [DisplayName("LoginId")]
        public string LoginId { get; set; }

        [DisplayName("Förnamn")]
        public string FName { get; set; }

        [DisplayName("Efternamn")]
        public string SName { get; set; }

        [Required]
        [DisplayName("Lösenord")]
        public string PassWD { get; set; }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        //public bool IsValid(string _username, string _password)
        //{
        //    return true;
        //}
    }
}