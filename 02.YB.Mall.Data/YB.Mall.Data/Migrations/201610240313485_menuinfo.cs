namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_MenuInfo", "IsMenu", c => c.Boolean(nullable: false,defaultValue:true));
            AddColumn("dbo.T_MenuInfo", "IsButton", c => c.Boolean(nullable: false,defaultValue:false));
            AddColumn("dbo.T_MenuInfo", "IsEnabled", c => c.Boolean(nullable: false,defaultValue:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_MenuInfo", "IsEnabled");
            DropColumn("dbo.T_MenuInfo", "IsButton");
            DropColumn("dbo.T_MenuInfo", "IsMenu");
        }
    }
}
