namespace ASPFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DetailText", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "DetailText");
        }
    }
}
