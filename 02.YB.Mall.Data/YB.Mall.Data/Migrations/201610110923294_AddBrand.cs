namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrand : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_ProductInfo", "CategoryId", "dbo.T_CategoryInfo");
            DropForeignKey("dbo.T_OrderInfo", "UserId", "dbo.T_UserInfo");
            CreateTable(
                "dbo.BrandInfoes",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 100),
                        Status = c.Int(),
                        Sort = c.Int(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            AddColumn("dbo.T_ProductInfo", "BrandId", c => c.Int(nullable: false));
            CreateIndex("dbo.T_ProductInfo", "BrandId");
            AddForeignKey("dbo.T_ProductInfo", "BrandId", "dbo.BrandInfoes", "BrandId");
            AddForeignKey("dbo.T_ProductInfo", "CategoryId", "dbo.T_CategoryInfo", "CategoryId");
            AddForeignKey("dbo.T_OrderInfo", "UserId", "dbo.T_UserInfo", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_OrderInfo", "UserId", "dbo.T_UserInfo");
            DropForeignKey("dbo.T_ProductInfo", "CategoryId", "dbo.T_CategoryInfo");
            DropForeignKey("dbo.T_ProductInfo", "BrandId", "dbo.BrandInfoes");
            DropIndex("dbo.T_ProductInfo", new[] { "BrandId" });
            DropColumn("dbo.T_ProductInfo", "BrandId");
            DropTable("dbo.BrandInfoes");
            AddForeignKey("dbo.T_OrderInfo", "UserId", "dbo.T_UserInfo", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.T_ProductInfo", "CategoryId", "dbo.T_CategoryInfo", "CategoryId", cascadeDelete: true);
        }
    }
}
