namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolemeun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_RoleMenuInfo",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.MenuId })
                .ForeignKey("dbo.T_MenuInfo", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.T_RoleInfo", t => t.MenuId, cascadeDelete: false)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);
            
            AddColumn("dbo.T_MenuInfo", "UrlPath", c => c.String(nullable: false, maxLength: 80));
            AddColumn("dbo.T_MenuInfo", "Target", c => c.String(nullable: false, maxLength: 20, defaultValue: "iframe"));
            AddColumn("dbo.T_MenuInfo", "LastUpdTime", c => c.DateTime());
            AlterColumn("dbo.T_ManageInfo", "Phone", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_RoleMenuInfo", "MenuId", "dbo.T_RoleInfo");
            DropForeignKey("dbo.T_RoleMenuInfo", "RoleId", "dbo.T_MenuInfo");
            DropIndex("dbo.T_RoleMenuInfo", new[] { "MenuId" });
            DropIndex("dbo.T_RoleMenuInfo", new[] { "RoleId" });
            AlterColumn("dbo.T_ManageInfo", "Phone", c => c.String());
            DropColumn("dbo.T_MenuInfo", "LastUpdTime");
            DropColumn("dbo.T_MenuInfo", "Target");
            DropColumn("dbo.T_MenuInfo", "UrlPath");
            DropTable("dbo.T_RoleMenuInfo");
        }
    }
}
