﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
    }
}