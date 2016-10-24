using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;

namespace YB.Mall.Service
{
    public class MenuButtonService : IMenuButtonService
    {
        private IMenuButtonRepository repository;
        private IUnitOfWork unitOfWork;
        public MenuButtonService(IMenuButtonRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
    }
}