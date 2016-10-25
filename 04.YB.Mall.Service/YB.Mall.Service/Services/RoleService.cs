using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;
using YB.Mall.Extend.Linq;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;
using YB.Mall.Extend.Helper;
namespace YB.Mall.Service
{
    public class RoleService : IRoleService
    {
        private IRoleRepository repository;
        private IMenuRepository menuRepository;
        private IUnitOfWork unitOfWork;
        public RoleService(IRoleRepository repository, IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }

        public List<RoleMenuViewModel> RoleMenu(int? roleId)
        {
            var grid = menuRepository.Query(s => s.IsEnabled);
            var list = new List<RoleMenuViewModel>();
            foreach (var item in grid.Where(s => s.ParentId == 0))
            {
                list.Add(new RoleMenuViewModel
                {
                    MenuId = item.MenuId,
                    ParentId = 0,
                    MenuName = item.MenuName,
                    Icon = item.Icon,
                    ChildrenNodes = grid.Where(s => s.ParentId == item.MenuId).Select(c => new Children
                    {
                        MenuId = c.MenuId,
                        ParentId = item.MenuId,
                        MenuName = c.MenuName,
                        Icon = c.Icon,
                        UrlPath = c.UrlPath,
                        Target = c.Target
                    }).ToList()
                });
            }
            return list;
        }

        public jqGridPagerViewModel<RoleInfo, dynamic> RoleGrid(RoleQueryModel query)
        {
            var predicate = PredicateBuilderUtility.True<RoleInfo>();
            if (!string.IsNullOrWhiteSpace(query.keyword))
                predicate = predicate.And(s => s.RoleName.Contains(query.keyword));
            var grid = repository.Pager(query, predicate);
            return new jqGridPagerViewModel<RoleInfo, dynamic>
            {
                rows = grid.rows.Select(s => new
                {
                    RoleId = s.RoleId,
                    RoleName = s.RoleName,
                    AllowDelte = s.AllowDelte,
                    AllowEdit = s.AllowEdit,
                    RoleType = ((RoleType) s.RoleType).ToDescription(),
                    OrganizeType = ((OrganizeType)s.OrganizeType).ToDescription(),
                    IsEnabled = s.IsEnabled,
                    Remark = s.Remark,
                    CreateTime=s.CreateTime
                }),
                size = grid.size,
                page = grid.page,
                records = grid.records
            };
        }


        public bool Remove(System.Linq.Expressions.Expression<System.Func<RoleInfo, bool>> where)
        {
            return repository.Delete(where);
        }

        public bool SubmitForm(RoleInfo role, int? keyValue)
        {
            throw new System.NotImplementedException();
        }

        public RoleInfo InitForm(Expression<Func<RoleInfo, bool>> where)
        {
            return repository.Single(where);
        }
    }
}