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
            this.ToTable("T_RoleInfo");
        }
    }
}