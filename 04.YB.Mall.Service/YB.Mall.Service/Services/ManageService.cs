using System.Linq;
using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;
using YB.Mall.Extend.Helper;
using YB.Mall.Extend.Linq;
using YB.Mall.Model;
using YB.Mall.Model.ViewModel;

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
            return repository.Single(s => s.Account.Equals(username) && s.PassWord.Equals(password));
        }
        public Model.ViewModel.jqGridPagerViewModel<Model.ManageInfo, dynamic> InitGrid(Model.QueryModel.ManageQueryModel query)
        {
            var predicate = PredicateBuilderUtility.True<ManageInfo>();
            if (!string.IsNullOrWhiteSpace(query.keyword))
                predicate = predicate.And(s => s.Account.Contains(query.keyword));
            var grid = repository.Pager(query, predicate);
            return new jqGridPagerViewModel<ManageInfo, dynamic>
            {
                rows = grid.rows.Select(s => new
                {
                    ManageId = s.ManageId,
                    Account = s.Account,
                    RealName = s.RealName,
                    Phone = s.Phone,
                    Birthday = s.Birthday,
                    Email = s.Email,
                    Description = s.Description,
                    IsEnabled = s.IsEnabled,
                    Gender = s.Gender
                }),
                size = grid.size,
                page = grid.page,
                records = grid.records
            };
        }

        public bool SubmitForm(ManageInfo mang, int? keyValue)
        {
            var flag = false;
            if (keyValue.HasValue)
            {
                mang.ManageId = keyValue.Value;
                repository.Update(mang);
                unitOfWork.SaveChanges();
            }
            else
            {
                repository.Add(mang);
                unitOfWork.SaveChanges();
                flag = mang.ManageId > 0;
            }
            return flag;
        }
    }
}