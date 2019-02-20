namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCampaignDatesType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campaigns", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Campaigns", "End", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Campaigns", "End", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Campaigns", "Start", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
