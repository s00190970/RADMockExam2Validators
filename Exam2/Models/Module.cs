using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam2.Models
{
    [Table("Module")]
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleID { get; set; }
        [Required]
        [Display(Name = "Module Name")]
        public string ModuleName { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}