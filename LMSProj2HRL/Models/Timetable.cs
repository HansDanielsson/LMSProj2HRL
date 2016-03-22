using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LMSProj2HRL.Models
{
    public enum DayName
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    public class Timetable
    {
        [Key, ForeignKey("SchoolClass")]
        public int TtId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Datum")]
        public DateTime DateTime { get; set; }

        [DisplayName("Lektion1")]
        public string Lesson1 { get; set; }

        [DisplayName("Lektion2")]
        public string Lesson2 { get; set; }

        [DisplayName("Lektion3")]
        public string Lesson3 { get; set; }

        [DisplayName("Lektion4")]
        public string Lesson4 { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
    }
}