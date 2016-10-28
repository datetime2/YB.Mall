using YB.Mall.Data.Infrastructure;

namespace YB.Mall.Service
{
    public class ManageRoleService : IManageRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IManageRoleService mroleService;
        public ManageRoleService(IUnitOfWork _unitOfWork, IManageRoleService _mroleService)
        {
            this.unitOfWork = _unitOfWork;
            this.mroleService = _mroleService;
        }
    }
}