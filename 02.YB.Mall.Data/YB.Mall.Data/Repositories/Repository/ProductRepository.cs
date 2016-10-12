using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class ProductRepository : Repository<ProductInfo>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}