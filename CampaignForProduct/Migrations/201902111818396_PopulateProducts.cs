namespace CampaignForProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProducts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products (Id, Name) VALUES (NEWID(), 'Coca Cola')");
            Sql("INSERT INTO Products (Id, Name) VALUES (NEWID(), 'Nike')");
        }
        
        public override void Down()
        {
        }
    }
}
