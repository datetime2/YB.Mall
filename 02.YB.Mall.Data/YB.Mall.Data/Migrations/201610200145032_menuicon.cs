namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuicon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_MenuInfo", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_MenuInfo", "Icon");
        }
    }
}
