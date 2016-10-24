namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuinfo1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_MenuInfo", "Icon", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_MenuInfo", "Icon", c => c.String());
        }
    }
}
