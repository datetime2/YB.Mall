namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_RoleInfo", "AllowDel", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_RoleInfo", "AllowEdit", c => c.Boolean(nullable: false));
            AlterColumn("dbo.T_RoleInfo", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_RoleInfo", "Status", c => c.Int());
            DropColumn("dbo.T_RoleInfo", "AllowEdit");
            DropColumn("dbo.T_RoleInfo", "AllowDel");
        }
    }
}
