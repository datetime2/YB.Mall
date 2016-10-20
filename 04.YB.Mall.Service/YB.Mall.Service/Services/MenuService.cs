using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;

namespace YB.Mall.Service
{
    public class MenuService : IMenuService
    {
        private IMenuRepository repository;
        private IUnitOfWork unitOfWork;
        public MenuService(IMenuRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
    }
}