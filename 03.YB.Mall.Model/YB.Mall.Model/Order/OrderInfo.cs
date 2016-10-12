using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Model
{
    public class OrderInfo
    {
        public OrderInfo()
        {
            this.OrderItemInfos=new HashSet<OrderItemInfo>();
        }
        public long OrderId { get; set; }
        public int Status { get; set; }
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateTime { get; set; }
        public int ShopId { get; set; }
        public string ShipUser { get; set; }
        public string Phone { get; set; }
        public string ShipAddress { get; set; }
        public virtual ICollection<OrderItemInfo> OrderItemInfos { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
