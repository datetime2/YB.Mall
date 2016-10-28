using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;

namespace YB.Mall.Service
{
    public interface IOrganizeService
    {
        MenuSelectModel<OrganizeGridModel> OrganizeGrid(MenuQueryModel query);
        List<TreeSelectModel> OrganizeTree(MenuQueryModel query);
        Organize InitForm(int menuId);
        bool SubmitForm(Organize orga, int? keyValue);
        bool Remove(Expression<Func<Organize, bool>> where);
    }
}