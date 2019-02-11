namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Campaigns", name: "Product_Id", newName: "ProductId");
            RenameIndex(table: "dbo.Campaigns", name: "IX_Product_Id", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Campaigns", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.Campaigns", name: "ProductId", newName: "Product_Id");
        }
    }
}
