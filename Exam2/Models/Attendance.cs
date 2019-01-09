using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Exam2.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceID { get; set; }
        [ForeignKey("ModuleAttended")]
        [Required]
        [Display(Name = "Module Attended")]
        public int ModuleID { get; set; }
        [ForeignKey("StudentAttended")]
        [Required]
        [Display(Name = "Student Attended")]
        public string CollegeID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Attendance Date")]
        [Column(TypeName = "DateTime")]
        public DateTime AttendanceDateTime { get; set; }
        [Required]
        [Display(Name = "Present")]
        public bool Present { get; set; }

        public virtual Module ModuleAttended { get; set; }
        public virtual Student StudentAttended { get; set; }
    }
}