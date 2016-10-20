using System.Collections.Generic;
using YB.Mall.Model.ViewModel;

namespace YB.Mall.Service
{
    public interface IRoleService
    {
        List<RoleMenuViewModel> RoleMenu(int? roleId);
    }
}