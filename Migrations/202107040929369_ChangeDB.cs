namespace BigSchoolRemake.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "LectureID", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LectureID" });
            AddColumn("dbo.Courses", "Lecturer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "LectureID", c => c.String(nullable: false));
            CreateIndex("dbo.Courses", "Lecturer_Id");
            AddForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecturer_Id" });
            AlterColumn("dbo.Courses", "LectureID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Courses", "Lecturer_Id");
            CreateIndex("dbo.Courses", "LectureID");
            AddForeignKey("dbo.Courses", "LectureID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
