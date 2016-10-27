namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_RoleInfo", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.T_RoleInfo", "LastUpdTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_RoleInfo", "LastUpdTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_RoleInfo", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
