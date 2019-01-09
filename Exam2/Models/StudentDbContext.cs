using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exam2.Models
{
    public class StudentDbContext: DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Student> Students { get; set; }
        public StudentDbContext() : base("Exam2017RepeatConnection")
        {

        }

        public static StudentDbContext Create()
        {
            return new StudentDbContext();
        }
    }
}