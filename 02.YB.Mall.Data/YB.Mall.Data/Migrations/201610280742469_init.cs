namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_ManageRoleInfo", "ManageId", "dbo.T_ManageInfo");
            DropForeignKey("dbo.T_ManageRoleInfo", "RoleId", "dbo.T_RoleInfo");
            DropIndex("dbo.T_ManageRoleInfo", new[] { "ManageId" });
            DropIndex("dbo.T_ManageRoleInfo", new[] { "RoleId" });
            CreateTable(
                "dbo.T_ManageRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManageId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_ManageInfo", t => t.ManageId, cascadeDelete: false)
                .ForeignKey("dbo.T_RoleInfo", t => t.RoleId, cascadeDelete: false)
                .Index(t => t.ManageId)
                .Index(t => t.RoleId);
            
            AddColumn("dbo.T_ManageInfo", "Account", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.T_ManageInfo", "IsEnabled", c => c.Boolean(nullable: false,defaultValue:true));
            AddColumn("dbo.T_ManageInfo", "Birthday", c => c.String(maxLength: 20));
            AddColumn("dbo.T_ManageInfo", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.T_ManageInfo", "Description", c => c.String(maxLength: 200));
            AddColumn("dbo.T_ManageInfo", "Gender", c => c.Boolean(nullable: false,defaultValue:true));
            DropColumn("dbo.T_ManageInfo", "ManageName");
            DropColumn("dbo.T_ManageInfo", "Status");
            DropTable("dbo.T_ManageRoleInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.T_ManageRoleInfo",
                c => new
                    {
                        ManageId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ManageId, t.RoleId });
            
            AddColumn("dbo.T_ManageInfo", "Status", c => c.Int());
            AddColumn("dbo.T_ManageInfo", "ManageName", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.T_ManageRole", "RoleId", "dbo.T_RoleInfo");
            DropForeignKey("dbo.T_ManageRole", "ManageId", "dbo.T_ManageInfo");
            DropIndex("dbo.T_ManageRole", new[] { "RoleId" });
            DropIndex("dbo.T_ManageRole", new[] { "ManageId" });
            DropColumn("dbo.T_ManageInfo", "Gender");
            DropColumn("dbo.T_ManageInfo", "Description");
            DropColumn("dbo.T_ManageInfo", "Email");
            DropColumn("dbo.T_ManageInfo", "Birthday");
            DropColumn("dbo.T_ManageInfo", "IsEnabled");
            DropColumn("dbo.T_ManageInfo", "Account");
            DropTable("dbo.T_ManageRole");
            CreateIndex("dbo.T_ManageRoleInfo", "RoleId");
            CreateIndex("dbo.T_ManageRoleInfo", "ManageId");
            AddForeignKey("dbo.T_ManageRoleInfo", "RoleId", "dbo.T_RoleInfo", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.T_ManageRoleInfo", "ManageId", "dbo.T_ManageInfo", "ManageId", cascadeDelete: true);
        }
    }
}
