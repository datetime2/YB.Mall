namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role1 : DbMigration
    {
        public override void Up()
        {
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
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ManageId);
            
            CreateTable(
                "dbo.T_RoleInfo",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.RoleId);
            
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
            DropForeignKey("dbo.T_ManageRoleInfo", "RoleId", "dbo.T_RoleInfo");
            DropForeignKey("dbo.T_ManageRoleInfo", "ManageId", "dbo.T_ManageInfo");
            DropIndex("dbo.T_ManageRoleInfo", new[] { "RoleId" });
            DropIndex("dbo.T_ManageRoleInfo", new[] { "ManageId" });
            DropTable("dbo.T_ManageRoleInfo");
            DropTable("dbo.T_RoleInfo");
            DropTable("dbo.T_ManageInfo");
        }
    }
}
