using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;
namespace YB.Mall.Data.Configurations
{
    internal class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            this.ToTable("T_UserInfo");
            this.HasKey(s => s.UserId);
            this.Property(s => s.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.UserName).IsRequired().HasMaxLength(50);
            this.Property(s => s.PassPlat).IsRequired().HasMaxLength(50);
            this.Property(s => s.PassWord).IsRequired().HasMaxLength(50);
            this.Property(s => s.LastLogIp).HasMaxLength(20);
            this.Property(s => s.Amount).HasPrecision(18, 2);
        }
    }
}
