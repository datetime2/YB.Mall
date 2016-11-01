using System.Collections.Generic;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;

namespace YB.Mall.Service
{
    public interface IManageService
    {
        bool Login(string username, string password);
        jqGridPagerViewModel<ManageInfo, dynamic> InitGrid(ManageQueryModel query);
        bool SubmitForm(ManageInfo mang, IEnumerable<int> roles, int? keyValue);
        ManageInfo InitForm(int manageId);
    }
}