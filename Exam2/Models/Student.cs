using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Exam2.Models
{
    [Table("Student")]
    public class Student : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Student ID")]
        public string CollegeID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CollegeID.Substring(0,1)!="S" || CollegeID.Length!= 9 || !IsAllLettersOrDigits(CollegeID))
            {
                yield return new ValidationResult
                    ("College ID must start with \'S\', be 9 characters long and contain only digits and letters", new[] { "CollegeID"});
            }
        }

        private static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
    }
}