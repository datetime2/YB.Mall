namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_MenuInfo", "Remark", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_MenuInfo", "Remark");
        }
    }
}
