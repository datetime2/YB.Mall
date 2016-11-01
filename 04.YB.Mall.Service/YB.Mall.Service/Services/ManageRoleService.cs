using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;

namespace YB.Mall.Service
{
    public class ManageRoleService : IManageRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IManageRoleRepository repository;
        public ManageRoleService(IUnitOfWork _unitOfWork, IManageRoleRepository _repository)
        {
            this.unitOfWork = _unitOfWork;
            this.repository = _repository;
        }
    }
}