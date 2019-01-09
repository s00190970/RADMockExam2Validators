namespace Exam2.Migrations.StudentMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        AttendanceID = c.Int(nullable: false, identity: true),
                        ModuleID = c.Int(nullable: false),
                        CollegeID = c.String(maxLength: 128),
                        AttendanceDateTime = c.DateTime(nullable: false),
                        Present = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceID)
                .ForeignKey("dbo.Module", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.CollegeID)
                .Index(t => t.ModuleID)
                .Index(t => t.CollegeID);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        ModuleID = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                    })
                .PrimaryKey(t => t.ModuleID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        CollegeID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.CollegeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendance", "CollegeID", "dbo.Student");
            DropForeignKey("dbo.Attendance", "ModuleID", "dbo.Module");
            DropIndex("dbo.Attendance", new[] { "CollegeID" });
            DropIndex("dbo.Attendance", new[] { "ModuleID" });
            DropTable("dbo.Student");
            DropTable("dbo.Module");
            DropTable("dbo.Attendance");
        }
    }
}
