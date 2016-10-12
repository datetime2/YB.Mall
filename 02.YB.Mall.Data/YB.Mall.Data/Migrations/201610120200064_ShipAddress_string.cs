namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShipAddress_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_OrderInfo", "ShipAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_OrderInfo", "ShipAddress", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
