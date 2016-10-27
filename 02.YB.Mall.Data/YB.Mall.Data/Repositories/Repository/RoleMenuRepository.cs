using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class RoleMenuRepository : Repository<RoleMenu>, IRoleMenuRepository
    {
        public RoleMenuRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}