using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    public class ManageRoleConfiguration : EntityTypeConfiguration<ManageRole>
    {
        public ManageRoleConfiguration()
        {
            this.HasKey(s => s.Id).Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ManageId).IsRequired();
            this.Property(s => s.RoleId).IsRequired();

            this.HasRequired(s => s.RoleInfo).WithMany(s => s.ManageRole).HasForeignKey(s => s.RoleId);
            this.HasRequired(s => s.ManageInfo).WithMany(s => s.ManageRole).HasForeignKey(s => s.ManageId);
            this.ToTable("T_ManageRoleInfo");
        }
    }
}