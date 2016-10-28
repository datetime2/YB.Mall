namespace YB.Mall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init000001 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.T_ManageRole", newName: "T_ManageRoleInfo");
            RenameTable(name: "dbo.T_RoleMenu", newName: "T_RoleMenuInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.T_RoleMenuInfo", newName: "T_RoleMenu");
            RenameTable(name: "dbo.T_ManageRoleInfo", newName: "T_ManageRole");
        }
    }
}
