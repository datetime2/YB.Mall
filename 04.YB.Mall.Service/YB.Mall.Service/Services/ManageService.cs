using System;
using System.Collections.Generic;
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
        private readonly IManageRepository repository;
        private readonly IManageRoleRepository mrepository;
        private IUnitOfWork unitOfWork;

        public ManageService(IManageRepository repository,
            IManageRoleRepository mrepository,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mrepository = mrepository;
            this.unitOfWork = unitOfWork;
        }
        public ManageInfo Login(string username, string password)
        {
            var flag = new ManageInfo();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;
            var mang = repository.Single(s => s.Account.Equals(username));
            if (mang != null && mang.PassWord.Equals(SecureHelper.Md5(password + mang.PassPlat)))
                flag = mang;
            return flag;
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
                    Gender = s.Gender,
                    Role = "超级管理员,仓库管理员"
                }),
                size = grid.size,
                page = grid.page,
                records = grid.records
            };
        }

        public bool SubmitForm(ManageInfo mang, IEnumerable<int> roles, int? keyValue)
        {
            var flag = false;
            var enumerable = roles as int[] ?? roles.ToArray();
            if (keyValue.HasValue)
            {
                if (repository.Update(s => s.ManageId == keyValue.Value, u => new ManageInfo
                {
                    Account = mang.Account,
                    RealName = mang.RealName,
                    Phone = u.Phone,
                    Birthday = u.Birthday,
                    Email = u.Email,
                    Description = u.Description,
                    IsEnabled = u.IsEnabled,
                    Gender = u.Gender
                }))
                {
                    if (enumerable.Any())
                        mrepository.Delete(s => s.ManageId == keyValue);
                    flag = mrepository.Add(enumerable.Select(s => new ManageRole
                    {
                        ManageId = keyValue.Value,
                        RoleId = s
                    })).Any();
                    unitOfWork.SaveChanges();
                }
            }
            else
            {
                var salt = Guid.NewGuid().ToString();
                mang.PassPlat = salt;
                mang.PassWord = SecureHelper.Md5(SecureHelper.Md5(mang.PassWord) + salt);
                repository.Add(mang);
                unitOfWork.SaveChanges();
                mrepository.Add(enumerable.Select(s => new ManageRole
                {
                    ManageId = mang.ManageId,
                    RoleId = s
                }));
                unitOfWork.SaveChanges();
                flag = mang.ManageId > 0;
            }
            return flag;
        }

        public ManageInfo InitForm(int manageId)
        {
            return repository.Single(s => s.ManageId == manageId);
        }
    }
}