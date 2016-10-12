using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Model
{
    public class UserInfo
    {
        public UserInfo()
        {
            this.OrderInfo = new HashSet<OrderInfo>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string PassPlat { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? LastLogTime { get; set; }
        public DateTime? LastUpdTime { get; set; }
        [DefaultValue(0)]
        public int? LoginNums { get; set; }
        public string LastLogIp { get; set; }
        public virtual ICollection<OrderInfo> OrderInfo { get; set; }
    }
}
