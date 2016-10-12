namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuinfo1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MenuInfoes", newName: "T_MenuInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.T_MenuInfo", newName: "MenuInfoes");
        }
    }
}
