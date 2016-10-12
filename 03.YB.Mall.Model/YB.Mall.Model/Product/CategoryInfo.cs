using System.Collections.Generic;

namespace YB.Mall.Model
{
    public class CategoryInfo
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public int Sort { get; set; }
        public virtual ICollection<ProductInfo> ProductInfos { get; set; } 
    }
}