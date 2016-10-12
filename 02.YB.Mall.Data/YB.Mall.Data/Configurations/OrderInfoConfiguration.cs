using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using YB.Mall.Model;

namespace YB.Mall.Data.Configurations
{
    internal class OrderInfoConfiguration : EntityTypeConfiguration<OrderInfo>
    {
        public OrderInfoConfiguration()
        {
            this.ToTable("T_OrderInfo");
            this.HasKey(s => s.OrderId);
            this.Property(s => s.Amount).HasPrecision(18, 2).IsRequired();
            this.Property(s => s.Status).IsRequired();
            this.Property(s => s.ShipUser).HasMaxLength(50);
            this.Property(s => s.Phone).HasMaxLength(20);
            this.Property(s => s.ShipAddress).HasMaxLength(50);
            this.HasRequired(s => s.UserInfo).WithMany(s => s.OrderInfo).HasForeignKey(s => s.UserId).WillCascadeOnDelete(false);
        }
    }
}