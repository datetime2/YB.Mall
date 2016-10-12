using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;

namespace YB.Mall.Service
{
    public class ManageService : IManageService
    {
        private IManageRepository repository;
        private IUnitOfWork unitOfWork;

        public ManageService(IManageRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public Model.ManageInfo Login(string username, string password)
        {
            return repository.Single(s => s.ManageName.Equals(username) && s.PassWord.Equals(password));
        }
    }
}