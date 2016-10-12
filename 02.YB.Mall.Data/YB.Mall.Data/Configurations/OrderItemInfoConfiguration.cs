using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    internal class OrderItemInfoConfiguration : EntityTypeConfiguration<OrderItemInfo>
    {
        public OrderItemInfoConfiguration()
        {
            this.ToTable("T_OrderItemInfo");
            this.HasKey(s => s.Id).Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.ProductId).IsRequired();
            this.Property(s => s.ProductName).IsRequired();
            this.Property(s => s.Quantity).IsRequired();
            this.Property(s => s.SkuId).IsRequired();
            this.Property(s => s.UnitPrice).HasPrecision(18, 2).IsRequired();
            this.HasRequired(s => s.OrderInfo).WithMany(s => s.OrderItemInfos).HasForeignKey(s => s.OrderId);
        }
    }
}