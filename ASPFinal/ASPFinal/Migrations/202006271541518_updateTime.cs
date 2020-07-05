namespace ASPFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Date", c => c.Time(nullable: false, precision: 7));
        }
    }
}
