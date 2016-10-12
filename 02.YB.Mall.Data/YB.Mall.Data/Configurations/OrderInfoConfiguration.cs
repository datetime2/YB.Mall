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

            this.HasRequired(s => s.UserInfo).WithMany(s => s.OrderInfo).HasForeignKey(s => s.UserId).WillCascadeOnDelete(false);
        }
    }
}