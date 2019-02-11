namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetTypeNameToDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campaigns", "Start", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Campaigns", "End", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Campaigns", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Campaigns", "Start", c => c.DateTime(nullable: false));
        }
    }
}
