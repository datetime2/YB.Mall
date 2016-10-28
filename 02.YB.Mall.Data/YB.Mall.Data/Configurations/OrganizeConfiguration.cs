using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.CompilerServices;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    public class OrganizeConfiguration : EntityTypeConfiguration<Organize>
    {
        public OrganizeConfiguration()
        {
            this.HasKey(s => s.OrganizeId)
                .Property(s => s.OrganizeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ParentId).IsRequired();
            this.Property(s => s.OrganizeName).HasMaxLength(100).IsRequired();
            this.Property(s => s.ManagerName).IsRequired().HasMaxLength(50);
            this.ToTable("T_OrganizeInfo");
        }
    }
}