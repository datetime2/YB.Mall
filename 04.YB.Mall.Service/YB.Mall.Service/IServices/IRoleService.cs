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
        bool Remove(Expression<Func<RoleInfo, bool>> where);
        bool SubmitForm(RoleInfo role, int? keyValue);
        RoleInfo InitForm(Expression<Func<RoleInfo, bool>> where);
        List<TreeViewModel> RoleAuthorize(int? roleId);
    }
}