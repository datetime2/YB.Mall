namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShipAddress_MaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_OrderInfo", "ShipUser", c => c.String(maxLength: 50));
            AlterColumn("dbo.T_OrderInfo", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.T_OrderInfo", "ShipAddress", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_OrderInfo", "ShipAddress", c => c.String());
            AlterColumn("dbo.T_OrderInfo", "Phone", c => c.String());
            AlterColumn("dbo.T_OrderInfo", "ShipUser", c => c.String());
        }
    }
}
