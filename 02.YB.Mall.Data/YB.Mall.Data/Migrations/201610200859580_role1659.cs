namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role1659 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_RoleInfo", "AllowDelte", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.T_RoleInfo", "RoleType", c => c.Int(nullable: false, defaultValue: 0));
            DropColumn("dbo.T_RoleInfo", "AllowDel");
        }

        public override void Down()
        {
            AddColumn("dbo.T_RoleInfo", "AllowDel", c => c.Boolean(nullable: false));
            DropColumn("dbo.T_RoleInfo", "RoleType");
            DropColumn("dbo.T_RoleInfo", "AllowDelte");
        }
    }
}
