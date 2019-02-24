namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductModel1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ProductDtoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductDtoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
