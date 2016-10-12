namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuInfoes",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        MenuName = c.String(nullable: false, maxLength: 50),
                        Status = c.Int(),
                        Sort = c.Int(),
                    })
                .PrimaryKey(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuInfoes");
        }
    }
}
