using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class OrderRepository:Repository<OrderInfo>,IOrderRepository
    {
        public OrderRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        } 
    }
}