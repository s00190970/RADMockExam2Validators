namespace Exam2.Migrations.StudentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelValidationandDisplay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendance", "CollegeID", "dbo.Student");
            DropIndex("dbo.Attendance", new[] { "CollegeID" });
            AlterColumn("dbo.Attendance", "CollegeID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Module", "ModuleName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.Attendance", "CollegeID");
            AddForeignKey("dbo.Attendance", "CollegeID", "dbo.Student", "CollegeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendance", "CollegeID", "dbo.Student");
            DropIndex("dbo.Attendance", new[] { "CollegeID" });
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            AlterColumn("dbo.Module", "ModuleName", c => c.String());
            AlterColumn("dbo.Attendance", "CollegeID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Attendance", "CollegeID");
            AddForeignKey("dbo.Attendance", "CollegeID", "dbo.Student", "CollegeID");
        }
    }
}
