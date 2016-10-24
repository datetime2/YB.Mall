using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    public class MenuButtonInfoConfiguration : EntityTypeConfiguration<MenuButtonInfo>
    {
        public MenuButtonInfoConfiguration()
        {
            this.HasKey(s => s.ButtonId)
                .Property(s => s.ButtonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.MenuId).IsRequired();
            this.Property(s => s.ButtonName).IsRequired().HasMaxLength(50);
            this.Property(s => s.ElementId).IsRequired().HasMaxLength(50);
            this.Property(s => s.Event).IsRequired().HasMaxLength(50);
            this.Property(s => s.Icon).IsRequired().HasMaxLength(50);
            this.HasRequired(s => s.MenuInfo).WithMany(s => s.MenuButtonInfo).HasForeignKey(s => s.MenuId);
            this.ToTable("T_MenuButtonInfo");
        }
    }
}