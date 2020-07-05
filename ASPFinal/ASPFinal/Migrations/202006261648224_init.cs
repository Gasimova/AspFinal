namespace ASPFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentTitle = c.String(maxLength: 500),
                        Text = c.String(maxLength: 1000),
                        Video = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 200),
                        Title = c.String(maxLength: 200),
                        Text = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ReadCount = c.String(),
                        UsersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.UsersId);
            
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        TextTitle = c.String(),
                        Text = c.String(),
                        CategoriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoriesId, cascadeDelete: true)
                .Index(t => t.CategoriesId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        CoursesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CoursesId, cascadeDelete: true)
                .Index(t => t.CoursesId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 300),
                        Phone = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Website = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 200),
                        Title = c.String(maxLength: 200),
                        Text = c.String(),
                        Date = c.Time(nullable: false, precision: 7),
                        Venue = c.String(maxLength: 200),
                        Time = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventToSpeakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventsId = c.Int(nullable: false),
                        SpeakersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Starts = c.String(maxLength: 100),
                        Duration = c.String(maxLength: 100),
                        ClassDuration = c.String(maxLength: 100),
                        SkillLevel = c.String(maxLength: 100),
                        Language = c.String(maxLength: 100),
                        Students = c.String(maxLength: 100),
                        Assetsments = c.String(maxLength: 100),
                        CourseFee = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainSliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Title = c.String(maxLength: 500),
                        Subtitle = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        Subject = c.String(maxLength: 200),
                        Message = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogoText = c.String(),
                        Copyright = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Profession = c.String(maxLength: 200),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Position = c.String(maxLength: 100),
                        Image = c.String(),
                        AboutMe = c.String(maxLength: 300),
                        Degree = c.String(maxLength: 100),
                        Experience = c.String(maxLength: 300),
                        Hobbies = c.String(maxLength: 300),
                        Faculty = c.String(maxLength: 300),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        Skype = c.String(maxLength: 100),
                        Language = c.String(),
                        TeamLeader = c.String(),
                        Development = c.String(),
                        Design = c.String(),
                        Innovation = c.String(),
                        Communication = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 200),
                        Text = c.String(maxLength: 500),
                        Person = c.String(maxLength: 200),
                        Position = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Username = c.String(maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Courses", "CategoriesId", "dbo.Categories");
            DropForeignKey("dbo.Tags", "CoursesId", "dbo.Courses");
            DropIndex("dbo.Tags", new[] { "CoursesId" });
            DropIndex("dbo.Courses", new[] { "CategoriesId" });
            DropIndex("dbo.Blogs", new[] { "UsersId" });
            DropTable("dbo.Users");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subscribes");
            DropTable("dbo.Speakers");
            DropTable("dbo.Settings");
            DropTable("dbo.Messages");
            DropTable("dbo.MainSliders");
            DropTable("dbo.Features");
            DropTable("dbo.EventToSpeakers");
            DropTable("dbo.Events");
            DropTable("dbo.Contacts");
            DropTable("dbo.Tags");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Boards");
            DropTable("dbo.Blogs");
            DropTable("dbo.Abouts");
        }
    }
}
