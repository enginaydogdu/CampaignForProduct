namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeProductNotNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campaigns", "ProductId", "dbo.Products");
            DropIndex("dbo.Campaigns", new[] { "ProductId" });
            AlterColumn("dbo.Campaigns", "ProductId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Campaigns", "ProductId");
            AddForeignKey("dbo.Campaigns", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campaigns", "ProductId", "dbo.Products");
            DropIndex("dbo.Campaigns", new[] { "ProductId" });
            AlterColumn("dbo.Campaigns", "ProductId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Campaigns", "ProductId");
            AddForeignKey("dbo.Campaigns", "ProductId", "dbo.Products", "Id");
        }
    }
}
