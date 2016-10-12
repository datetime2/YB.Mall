using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class BrandRepository:Repository<BrandInfo>,IBrandRepository
    {
        public BrandRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }
    }
}