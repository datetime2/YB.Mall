using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class OrganizeRepository : Repository<Organize>, IOrganizeRepository
    {
        public OrganizeRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}