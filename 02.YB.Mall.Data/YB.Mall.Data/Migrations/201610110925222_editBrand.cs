namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editBrand : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BrandInfoes", newName: "T_BrandInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.T_BrandInfo", newName: "BrandInfoes");
        }
    }
}
