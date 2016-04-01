using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSProj2HRL.Models
{
    public class SchoolClass
    {
        [Key]
        public int SCId { get; set; }

        [DisplayName("Klass")]
        public string Name { get; set; }

        #region Teacher Foreign Key
        //[DisplayName("Lärare")]
        public int TeId { get; set; }

        [ForeignKey("TeId")]
        public virtual Teacher Teacher { get; set; }
        #endregion Teacher Foreign Key

        #region Timetable Foreign Key
        public virtual Timetable Timetable { get; set; }
        #endregion Timetable Foreign Key
    }
}