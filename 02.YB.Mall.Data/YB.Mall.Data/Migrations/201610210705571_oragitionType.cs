namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oragitionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_RoleInfo", "OrganizeType", c => c.Int(nullable: false,defaultValue:0));
            AddColumn("dbo.T_RoleInfo", "Sort", c => c.Int(nullable: false,defaultValue:0));
            AddColumn("dbo.T_RoleInfo", "Remark", c => c.String(maxLength: 200));
            AlterColumn("dbo.T_RoleInfo", "AllowDelte", c => c.Boolean(nullable: false, defaultValue: true));
            AlterColumn("dbo.T_RoleInfo", "AllowEdit", c => c.Boolean(nullable: false, defaultValue: true));
            AlterColumn("dbo.T_RoleInfo", "RoleType", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_RoleInfo", "Remark");
            DropColumn("dbo.T_RoleInfo", "Sort");
            DropColumn("dbo.T_RoleInfo", "OrganizeType");
        }
    }
}
