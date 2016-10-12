namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201610111646 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.T_OrderItemInfo", "ProductId");
            AddForeignKey("dbo.T_OrderItemInfo", "ProductId", "dbo.T_ProductInfo", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_OrderItemInfo", "ProductId", "dbo.T_ProductInfo");
            DropIndex("dbo.T_OrderItemInfo", new[] { "ProductId" });
        }
    }
}
