using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    internal class BrandInfoConfiguration:EntityTypeConfiguration<BrandInfo>
    {
        public BrandInfoConfiguration()
        {
            this.HasKey(s => s.BrandId)
                .Property(s => s.BrandId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.BrandName).IsRequired().HasMaxLength(100);
            this.ToTable("T_BrandInfo");
        }
    }
}