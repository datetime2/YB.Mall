using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Model
{
    public class BrandInfo
    {
        public BrandInfo()
        {
            this.ProductInfos=new HashSet<ProductInfo>();
        }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int? Status { get; set; }
        public int? Sort { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<ProductInfo> ProductInfos { get; set; }
    }
}
