using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    internal class ProductInfoConfiguration : EntityTypeConfiguration<ProductInfo>
    {
        public ProductInfoConfiguration()
        {
            this.ToTable("T_ProductInfo");
            this.HasKey(s => s.ProductId)
                .Property(s => s.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ProductName).HasMaxLength(150).IsRequired();
            this.HasRequired(s => s.CategoryInfo).WithMany(s => s.ProductInfos).HasForeignKey(s => s.CategoryId).WillCascadeOnDelete(false);
            this.HasRequired(s => s.BrandInfo).WithMany(s => s.ProductInfos).HasForeignKey(s => s.BrandId).WillCascadeOnDelete(false);
        }
    }
}