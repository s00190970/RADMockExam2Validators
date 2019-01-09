namespace Exam2.Migrations.ApplicationMigrations
{
    using Exam2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exam2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationMigrations";
        }

        protected override void Seed(Exam2.Models.ApplicationDbContext context)
        {
            var manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Student" }
            );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Lecturer" }
            );

            context.SaveChanges();

            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "cristian.beckert@mail.itsligo.ie",
                    Email = "cristian.beckert@mail.itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("zxcvbnm"),
                    RoleID = 1
                });
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "cristina.mihaila@mail.itsligo.ie",
                    Email = "cristina.mihaila@mail.itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("zxcvbnm"),
                    RoleID = 1
                });
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "paul.powwel@itsligo.ie",
                    Email = "paul.powwel@itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("lecturer"),
                    RoleID = 2
                });
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "padraig.harte@itsligo.ie",
                    Email = "padraig.harte@itsligo.ie",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("lecturer"),
                    RoleID = 2
                });

            context.SaveChanges();

            ApplicationUser lecturer = manager.FindByEmail("paul.powwel@itsligo.ie");
            if (lecturer != null)
            {
                manager.AddToRoles(lecturer.Id, new string[] { "Lecturer" });
            }
            lecturer = manager.FindByEmail("padraig.harte@itsligo.ie");
            if (lecturer != null)
            {
                manager.AddToRoles(lecturer.Id, new string[] { "Lecturer" });
            }
            ApplicationUser student = manager.FindByEmail("cristina.mihaila@mail.itsligo.ie");
            if (student != null)
            {
                manager.AddToRoles(student.Id, new string[] { "Student" });
            }
            student = manager.FindByEmail("cristian.beckert@mail.itsligo.ie");
            if (student != null)
            {
                manager.AddToRoles(student.Id, new string[] { "Student" });
            }

            context.SaveChanges();
        }
    }
}
