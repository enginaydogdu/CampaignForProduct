namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campaigns", "Start", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Campaigns", "End", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Campaigns", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Campaigns", "Start", c => c.DateTime(nullable: false));
        }
    }
}
