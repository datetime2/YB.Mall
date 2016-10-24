namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeStatus : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.T_MenuInfo", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_MenuInfo", "Status", c => c.Int());
        }
    }
}
