namespace YB.Mall.Model
{
    public class OrderItemInfo
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string SkuId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual OrderInfo OrderInfo { get; set; }
        public virtual ProductInfo ProductInfo { get; set; }
    }
}