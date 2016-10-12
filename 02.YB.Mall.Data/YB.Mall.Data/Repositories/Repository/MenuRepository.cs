using YB.Mall.Data.Infrastructure;
using YB.Mall.Model;

namespace YB.Mall.Data.Repositories
{
    public class MenuRepository:Repository<MenuInfo>,IMenuRepository
    {
        public MenuRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
            
        }
    }
}