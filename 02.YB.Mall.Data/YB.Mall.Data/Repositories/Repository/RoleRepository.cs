using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class RoleRepository : Repository<RoleInfo>, IRoleRepository
    {
        public RoleRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}