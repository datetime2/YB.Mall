using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class UserRepository : Repository<UserInfo>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}