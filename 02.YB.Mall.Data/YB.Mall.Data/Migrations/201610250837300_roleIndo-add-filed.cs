namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleIndoaddfiled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_RoleInfo", "CreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.T_RoleInfo", "IsEnabled", c => c.Boolean(nullable: false,defaultValue:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_RoleInfo", "IsEnabled");
            DropColumn("dbo.T_RoleInfo", "CreateTime");
        }
    }
}
