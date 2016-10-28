using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    internal class RoleInfoConfiguration:EntityTypeConfiguration<RoleInfo>
    {
        public RoleInfoConfiguration()
        {
            this.HasKey(s => s.RoleId)
                .Property(s => s.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.RoleName).HasMaxLength(50).IsRequired();
            this.Property(s => s.Status).IsRequired();
            this.Property(s => s.AllowDelte).IsRequired();
            this.Property(s => s.AllowEdit).IsRequired();
            this.Property(s => s.RoleType).IsRequired();
            this.Property(s => s.OrganizeId);
            this.Property(s => s.Sort).IsRequired();
            this.Property(s => s.Remark).HasMaxLength(200);
            this.ToTable("T_RoleInfo");
        }
    }
}