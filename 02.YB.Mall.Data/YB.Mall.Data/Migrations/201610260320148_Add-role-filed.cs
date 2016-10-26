namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Addrolefiled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_RoleInfo", "LastUpdTime", c => c.DateTime(nullable: false));
            Sql("DBCC CHECKIDENT ('dbo.T_MenuInfo', 10000)");
            Sql("DBCC CHECKIDENT ('dbo.T_MenuButtonInfo', 20000)");
        }

        public override void Down()
        {
            DropColumn("dbo.T_RoleInfo", "LastUpdTime");
        }
    }
}
