namespace ASPFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLogo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "Logo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "Logo");
        }
    }
}
