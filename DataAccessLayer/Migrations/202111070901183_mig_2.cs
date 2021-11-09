namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "CategoryID" });
            DropIndex("dbo.Headings", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropColumn("dbo.Writers", "WriterTitle");
            DropTable("dbo.Categories");
            DropTable("dbo.Headings");
            DropTable("dbo.Contents");
            DropTable("dbo.TalentCards");
            DropTable("dbo.Talents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        TalentName = c.String(),
                        Range = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TalentId);
            
            CreateTable(
                "dbo.TalentCards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Text = c.String(maxLength: 50),
                        Skill = c.String(maxLength: 20),
                        SkillPoint = c.Int(nullable: false),
                        Skill2 = c.String(maxLength: 20),
                        SkillPoint2 = c.Int(nullable: false),
                        Skill3 = c.String(maxLength: 20),
                        SkillPoint3 = c.Int(nullable: false),
                        Skill4 = c.String(maxLength: 20),
                        SkillPoint4 = c.Int(nullable: false),
                        Skill5 = c.String(maxLength: 20),
                        SkillPoint5 = c.Int(nullable: false),
                        Skill6 = c.String(maxLength: 20),
                        SkillPoint6 = c.Int(nullable: false),
                        Skill7 = c.String(maxLength: 20),
                        SkillPoint7 = c.Int(nullable: false),
                        Skill8 = c.String(maxLength: 20),
                        SkillPoint8 = c.Int(nullable: false),
                        Skill9 = c.String(maxLength: 20),
                        SkillPoint9 = c.Int(nullable: false),
                        Skill10 = c.String(maxLength: 20),
                        SkillPoint10 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        ContentStatus = c.Boolean(nullable: false),
                        HeadingID = c.Int(nullable: false),
                        WriterID = c.Int(),
                    })
                .PrimaryKey(t => t.ContentID);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 50),
                        HeadingDate = c.DateTime(nullable: false),
                        HeadingStatus = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadingID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryDescription = c.String(maxLength: 200),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            AddColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            CreateIndex("dbo.Contents", "WriterID");
            CreateIndex("dbo.Contents", "HeadingID");
            CreateIndex("dbo.Headings", "WriterID");
            CreateIndex("dbo.Headings", "CategoryID");
            AddForeignKey("dbo.Headings", "WriterID", "dbo.Writers", "WriterId", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterId");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID", cascadeDelete: true);
            AddForeignKey("dbo.Headings", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
