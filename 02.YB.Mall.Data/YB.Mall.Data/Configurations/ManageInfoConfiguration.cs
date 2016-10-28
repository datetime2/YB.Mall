using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    internal class ManageInfoConfiguration : EntityTypeConfiguration<ManageInfo>
    {
        public ManageInfoConfiguration()
        {
            this.HasKey(s => s.ManageId)
                .Property(s => s.ManageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(s => s.Account).HasMaxLength(50).IsRequired();
            this.Property(s => s.RealName).HasMaxLength(50).IsRequired();
            this.Property(s => s.PassPlat).HasMaxLength(50).IsRequired();
            this.Property(s => s.PassWord).HasMaxLength(50).IsRequired();
            this.Property(s => s.Phone).HasMaxLength(20);

            this.Property(s => s.Birthday).HasMaxLength(20);
            this.Property(s => s.Email).HasMaxLength(50);
            this.Property(s => s.Description).HasMaxLength(200);

            //this.HasMany(s => s.RoleInfo).WithMany(s => s.ManageInfo).Map(mr =>
            //{
            //    mr.MapLeftKey("ManageId");
            //    mr.MapRightKey("RoleId");
            //    mr.ToTable("T_ManageRoleInfo");
            //});
            this.ToTable("T_ManageInfo");
        }
    }
}