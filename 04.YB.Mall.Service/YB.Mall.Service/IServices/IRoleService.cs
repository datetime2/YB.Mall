using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;
namespace YB.Mall.Service
{
    public interface IRoleService
    {
        List<RoleMenuViewModel> RoleMenu(int? roleId);
        jqGridPagerViewModel<RoleInfo, dynamic> RoleGrid(RoleQueryModel query);
    }
}