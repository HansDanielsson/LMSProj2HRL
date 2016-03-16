using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMSProj2HRL.Models
{
    public class Student
    {
        [Key]
        public int StId { get; set; }

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
    }
}