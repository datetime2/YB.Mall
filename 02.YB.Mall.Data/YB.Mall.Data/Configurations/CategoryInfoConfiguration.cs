using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    internal class CategoryInfoConfiguration:EntityTypeConfiguration<CategoryInfo>
    {
        public CategoryInfoConfiguration()
        {
            this.ToTable("T_CategoryInfo");
            this.HasKey(s => s.CategoryId)
                .Property(s => s.CategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}