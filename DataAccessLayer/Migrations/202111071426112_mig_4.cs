namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutDetails1", c => c.String(maxLength: 1000));
            DropColumn("dbo.Abouts", "AboutDetails2");
            DropColumn("dbo.Abouts", "AboutImage2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AddColumn("dbo.Abouts", "AboutDetails2", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Abouts", "AboutDetails1", c => c.String(maxLength: 500));
        }
    }
}
