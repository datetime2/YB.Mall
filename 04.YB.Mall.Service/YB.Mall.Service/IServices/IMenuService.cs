using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;

namespace YB.Mall.Service
{
    public interface IMenuService
    {
        MenuSelectModel MenuGrid(MenuQueryModel query);
        List<TreeSelectModel> MenuTree(MenuQueryModel query);
        MenuInfo InitForm(int menuId);
        bool SubmitForm(MenuInfo menu, int? keyValue);
        bool Remove(Expression<Func<MenuInfo, bool>> where);
    }
}