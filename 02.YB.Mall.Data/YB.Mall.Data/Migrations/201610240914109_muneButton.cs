namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class muneButton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_MenuButtonInfo",
                c => new
                    {
                        ButtonId = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        ButtonName = c.String(nullable: false, maxLength: 50),
                        ElementId = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(nullable: false, maxLength: 50),
                        Event = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ButtonId)
                .ForeignKey("dbo.T_MenuInfo", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_MenuButtonInfo", "MenuId", "dbo.T_MenuInfo");
            DropIndex("dbo.T_MenuButtonInfo", new[] { "MenuId" });
            DropTable("dbo.T_MenuButtonInfo");
        }
    }
}
