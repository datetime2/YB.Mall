using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    public class MenuInfoConfiguration:EntityTypeConfiguration<MenuInfo>
    {
        public MenuInfoConfiguration()
        {
            this.HasKey(s => s.MenuId)
                .Property(s => s.MenuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.MenuName).HasMaxLength(50).IsRequired();
            this.Property(s => s.ParentId).IsRequired();
            this.Property(s => s.Target).IsRequired().HasMaxLength(20);
            this.Property(s => s.UrlPath).IsRequired().HasMaxLength(80);
            this.HasMany(s => s.RoleInfo).WithMany(s => s.MenuInfo).Map(rm =>
            {
                rm.MapLeftKey("RoleId");
                rm.MapRightKey("MenuId");
                rm.ToTable("T_RoleMenuInfo");
            });
            this.ToTable("T_MenuInfo");
        }
    }
}