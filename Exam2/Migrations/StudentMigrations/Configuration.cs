using Exam2.Models;

namespace Exam2.Migrations.StudentMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exam2.Models.StudentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\StudentMigrations";
        }

        protected override void Seed(Exam2.Models.StudentDbContext context)
        {
            context.Students.AddOrUpdate(new Student[]
            {
                new Student
                {
                    CollegeID = "S00190970", FirstName = "Cristian", LastName = "Beckert"
                },
                new Student
                {
                    CollegeID = "S00123456", FirstName = "Crissy", LastName = "Mihaila"
                }
            });
            context.SaveChanges();

            context.Modules.AddOrUpdate(new Module[]
            {
                new Module
                {
                    ModuleName = "Rich Applications Development"
                },
                new Module
                {
                    ModuleName = "Software Project Management"
                }
            });
            context.SaveChanges();

            Student Crissy = new Student();
            Crissy = context.Students.Where(s => s.FirstName == "Crissy").FirstOrDefault();
            context.Attendances.AddOrUpdate(new Attendance[]
            {
                new Attendance
                {
                    CollegeID = context.Students.Where(s => s.FirstName == "Cristian").FirstOrDefault().CollegeID,
                    ModuleID = 1, AttendanceDateTime = DateTime.Today, Present = true
                }, 
                new Attendance
                {
                    CollegeID = context.Students.Where(s => s.FirstName == "Crissy").FirstOrDefault().CollegeID,
                    ModuleID = 2, AttendanceDateTime = DateTime.Today, Present = true
                }
            });
            context.SaveChanges();
        }
    }
}
