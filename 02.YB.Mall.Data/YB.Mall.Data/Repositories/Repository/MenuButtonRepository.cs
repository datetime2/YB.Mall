using System.Security.Cryptography.X509Certificates;
using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class MenuButtonRepository : Repository<MenuButtonInfo>, IMenuButtonRepository
    {
        public MenuButtonRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}