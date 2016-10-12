namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_CategoryInfo",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Status = c.Int(nullable: false),
                        Sort = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.T_ProductInfo",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 150),
                        CategoryId = c.Long(nullable: false),
                        ProductImg = c.String(),
                        SeoKey = c.String(),
                        SeoDescription = c.String(),
                        Description = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        LastUpdTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.T_CategoryInfo", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.T_OrderInfo",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateTime = c.DateTime(nullable: false),
                        ShopId = c.Int(nullable: false),
                        ShipUser = c.String(),
                        Phone = c.String(),
                        ShipAddress = c.String(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.T_UserInfo", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.T_OrderItemInfo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                        ProductName = c.String(nullable: false),
                        SkuId = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_OrderInfo", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);

            CreateTable(
                "dbo.T_UserInfo",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false, maxLength: 50),
                        PassPlat = c.String(nullable: false, maxLength: 50),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateTime = c.DateTime(nullable: false),
                        LastLogTime = c.DateTime(),
                        LastUpdTime = c.DateTime(),
                        LoginNums = c.Int(),
                        LastLogIp = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_OrderInfo", "UserId", "dbo.T_UserInfo");
            DropForeignKey("dbo.T_OrderItemInfo", "OrderId", "dbo.T_OrderInfo");
            DropForeignKey("dbo.T_ProductInfo", "CategoryId", "dbo.T_CategoryInfo");
            DropIndex("dbo.T_OrderItemInfo", new[] { "OrderId" });
            DropIndex("dbo.T_OrderInfo", new[] { "UserId" });
            DropIndex("dbo.T_ProductInfo", new[] { "CategoryId" });
            DropTable("dbo.T_UserInfo");
            DropTable("dbo.T_OrderItemInfo");
            DropTable("dbo.T_OrderInfo");
            DropTable("dbo.T_ProductInfo");
            DropTable("dbo.T_CategoryInfo");
        }
    }
}
