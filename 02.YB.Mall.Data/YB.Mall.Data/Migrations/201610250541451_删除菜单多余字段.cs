namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 删除菜单多余字段 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_MenuInfo", "IsButton");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_MenuInfo", "IsButton", c => c.Boolean(nullable: false));
        }
    }
}
