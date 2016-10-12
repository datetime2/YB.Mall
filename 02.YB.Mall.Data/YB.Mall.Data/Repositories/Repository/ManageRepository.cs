using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class ManageRepository:Repository<ManageInfo>,IManageRepository
    {
        public ManageRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }
    }
}