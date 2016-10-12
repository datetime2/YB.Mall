using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class OrderItemRepository:Repository<OrderItemInfo>,IOrderItemRepository
    {
        public OrderItemRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }
    }
}