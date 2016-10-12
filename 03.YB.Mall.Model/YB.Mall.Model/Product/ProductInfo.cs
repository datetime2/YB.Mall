using System;

namespace YB.Mall.Model
{
    public class ProductInfo
    {
        public long ProductId { get; set; }
        public int Status { get; set; }
        public string ProductName { get; set; }
        public long CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ProductImg { get; set; }
        public string SeoKey { get; set; }
        public string SeoDescription { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdTime { get; set; }
        public virtual CategoryInfo CategoryInfo { get; set; }
        public virtual BrandInfo BrandInfo { get; set; }
    }
}