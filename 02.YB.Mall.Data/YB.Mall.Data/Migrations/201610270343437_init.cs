namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_BrandInfo",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(),
                        Sort = c.Int(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.T_ProductInfo",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 150),
                        CategoryId = c.Long(nullable: false),
                        BrandId = c.Int(nullable: false),
                        ProductImg = c.String(),
                        SeoKey = c.String(),
                        SeoDescription = c.String(),
                        Description = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        LastUpdTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.T_BrandInfo", t => t.BrandId)
                .ForeignKey("dbo.T_CategoryInfo", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
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
                "dbo.T_ManageInfo",
                c => new
                    {
                        ManageId = c.Int(nullable: false, identity: true),
                        ManageName = c.String(nullable: false, maxLength: 50),
                        RealName = c.String(nullable: false, maxLength: 50),
                        PassPlat = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false, maxLength: 50),
                        Status = c.Int(),
                        Phone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ManageId);
            
            CreateTable(
                "dbo.T_RoleInfo",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        Status = c.Int(nullable: false),
                        AllowDelte = c.Boolean(nullable: false),
                        AllowEdit = c.Boolean(nullable: false),
                        RoleType = c.Int(nullable: false),
                        OrganizeType = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Sort = c.Int(nullable: false),
                        Remark = c.String(maxLength: 200),
                        LastUpdTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.T_RoleMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_MenuInfo", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.T_RoleInfo", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.T_MenuInfo",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        MenuName = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(maxLength: 30),
                        UrlPath = c.String(maxLength: 80),
                        Target = c.String(maxLength: 20),
                        ElementId = c.String(maxLength: 50),
                        Event = c.String(maxLength: 50),
                        Sort = c.Int(),
                        MenuType = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Remark = c.String(maxLength: 200),
                        LastUpdTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.MenuId);
            
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
                        ShipUser = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 20),
                        ShipAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.T_UserInfo", t => t.UserId)
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
                .ForeignKey("dbo.T_ProductInfo", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
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
            
            CreateTable(
                "dbo.T_ManageRoleInfo",
                c => new
                    {
                        ManageId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ManageId, t.RoleId })
                .ForeignKey("dbo.T_ManageInfo", t => t.ManageId, cascadeDelete: true)
                .ForeignKey("dbo.T_RoleInfo", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.ManageId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_OrderInfo", "UserId", "dbo.T_UserInfo");
            DropForeignKey("dbo.T_OrderItemInfo", "ProductId", "dbo.T_ProductInfo");
            DropForeignKey("dbo.T_OrderItemInfo", "OrderId", "dbo.T_OrderInfo");
            DropForeignKey("dbo.T_ManageRoleInfo", "RoleId", "dbo.T_RoleInfo");
            DropForeignKey("dbo.T_ManageRoleInfo", "ManageId", "dbo.T_ManageInfo");
            DropForeignKey("dbo.T_RoleMenu", "RoleId", "dbo.T_RoleInfo");
            DropForeignKey("dbo.T_RoleMenu", "MenuId", "dbo.T_MenuInfo");
            DropForeignKey("dbo.T_ProductInfo", "CategoryId", "dbo.T_CategoryInfo");
            DropForeignKey("dbo.T_ProductInfo", "BrandId", "dbo.T_BrandInfo");
            DropIndex("dbo.T_ManageRoleInfo", new[] { "RoleId" });
            DropIndex("dbo.T_ManageRoleInfo", new[] { "ManageId" });
            DropIndex("dbo.T_OrderItemInfo", new[] { "ProductId" });
            DropIndex("dbo.T_OrderItemInfo", new[] { "OrderId" });
            DropIndex("dbo.T_OrderInfo", new[] { "UserId" });
            DropIndex("dbo.T_RoleMenu", new[] { "MenuId" });
            DropIndex("dbo.T_RoleMenu", new[] { "RoleId" });
            DropIndex("dbo.T_ProductInfo", new[] { "BrandId" });
            DropIndex("dbo.T_ProductInfo", new[] { "CategoryId" });
            DropTable("dbo.T_ManageRoleInfo");
            DropTable("dbo.T_UserInfo");
            DropTable("dbo.T_OrderItemInfo");
            DropTable("dbo.T_OrderInfo");
            DropTable("dbo.T_MenuInfo");
            DropTable("dbo.T_RoleMenu");
            DropTable("dbo.T_RoleInfo");
            DropTable("dbo.T_ManageInfo");
            DropTable("dbo.T_CategoryInfo");
            DropTable("dbo.T_ProductInfo");
            DropTable("dbo.T_BrandInfo");
        }
    }
}
