namespace LMSProj2HRL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        SCId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeId = c.Int(nullable: false),
                        StId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SCId)
                .ForeignKey("dbo.Students", t => t.StId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeId, cascadeDelete: true)
                .Index(t => t.TeId)
                .Index(t => t.StId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StId = c.Int(nullable: false, identity: true),
                        LoginId = c.String(nullable: false),
                        FName = c.String(),
                        SName = c.String(),
                        PassWD = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeId = c.Int(nullable: false, identity: true),
                        LoginId = c.String(nullable: false),
                        FName = c.String(),
                        SName = c.String(),
                        PassWD = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeId);
            
            CreateTable(
                "dbo.Timetables",
                c => new
                    {
                        TtId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Lesson1 = c.String(),
                        Lesson2 = c.String(),
                        Lesson3 = c.String(),
                        Lesson4 = c.String(),
                    })
                .PrimaryKey(t => t.TtId)
                .ForeignKey("dbo.SchoolClasses", t => t.TtId)
                .Index(t => t.TtId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timetables", "TtId", "dbo.SchoolClasses");
            DropForeignKey("dbo.SchoolClasses", "TeId", "dbo.Teachers");
            DropForeignKey("dbo.SchoolClasses", "StId", "dbo.Students");
            DropIndex("dbo.Timetables", new[] { "TtId" });
            DropIndex("dbo.SchoolClasses", new[] { "StId" });
            DropIndex("dbo.SchoolClasses", new[] { "TeId" });
            DropTable("dbo.Timetables");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.SchoolClasses");
        }
    }
}
