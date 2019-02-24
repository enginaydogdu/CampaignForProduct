namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIsActive : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Campaigns", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "IsActive", c => c.Boolean(nullable: false));
        }
    }
}
