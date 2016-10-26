namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menubutton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_RoleMenuButtonInfo",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ButtonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ButtonId })
                .ForeignKey("dbo.T_MenuButtonInfo", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.T_RoleInfo", t => t.ButtonId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ButtonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_RoleMenuButtonInfo", "ButtonId", "dbo.T_RoleInfo");
            DropForeignKey("dbo.T_RoleMenuButtonInfo", "RoleId", "dbo.T_MenuButtonInfo");
            DropIndex("dbo.T_RoleMenuButtonInfo", new[] { "ButtonId" });
            DropIndex("dbo.T_RoleMenuButtonInfo", new[] { "RoleId" });
            DropTable("dbo.T_RoleMenuButtonInfo");
        }
    }
}
