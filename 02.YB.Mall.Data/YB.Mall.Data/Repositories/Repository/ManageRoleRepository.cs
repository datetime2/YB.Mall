using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class ManageRoleRepository : Repository<ManageRole>, IManageRoleRepository
    {
        public ManageRoleRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }
    }
}