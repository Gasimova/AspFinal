namespace ASPFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumn2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Text", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Text", c => c.String(maxLength: 500));
        }
    }
}
