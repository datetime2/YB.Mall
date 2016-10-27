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
        private readonly IRoleRepository repository;
        private readonly IMenuRepository menuRepository;
        private readonly IRoleMenuRepository rmenuRepository;
        private IUnitOfWork unitOfWork;
        public RoleService(IRoleRepository repository,
            IMenuRepository menuRepository,
            IRoleMenuRepository rmenuRepository,
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.menuRepository = menuRepository;
            this.rmenuRepository = rmenuRepository;
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
                    RoleType = ((RoleType)s.RoleType).ToDescription(),
                    OrganizeType = ((OrganizeType)s.OrganizeType).ToDescription(),
                    IsEnabled = s.IsEnabled,
                    Remark = s.Remark,
                    CreateTime = s.CreateTime
                }),
                size = grid.size,
                page = grid.page,
                records = grid.records
            };
        }
        public bool Remove(Expression<Func<RoleInfo, bool>> where)
        {
            return repository.Delete(where);
        }
        public bool SubmitForm(RoleInfo role, IEnumerable<int> menuIds, int? keyValue)
        {
            var flag = false;
            if (keyValue.HasValue)
            {
                if (menuIds.Any())
                    rmenuRepository.Delete(s => s.RoleId == keyValue);
                repository.Update(role);
                rmenuRepository.Add(menuIds.Select(s => new RoleMenu
                {
                    RoleId = keyValue.Value,
                    MenuId = s
                }));
                unitOfWork.SaveChanges();
            }
            else
            {
                role.CreateTime = DateTime.Now;
                role.LastUpdTime = DateTime.Now;
                repository.Add(role);
                unitOfWork.SaveChanges();
                rmenuRepository.Add(menuIds.Select(s => new RoleMenu
                {
                    RoleId = role.RoleId,
                    MenuId = s
                }));
                unitOfWork.SaveChanges();
                flag = role.RoleId > 0;
            }
            return flag;
        }
        public RoleInfo InitForm(Expression<Func<RoleInfo, bool>> where)
        {
            return repository.Single(where);
        }
        public List<TreeViewModel> RoleAuthorize(int? roleId)
        {
            var sysMenu = menuRepository.GetMany(s => s.IsEnabled);
            //var role = repository.Single(s => s.RoleId == roleId);
            //tree.AddRange(role.MenuButtonInfo.Select(s => new TreeViewModel
            //{

            //}));
            return sysMenu.Where(s => s.ParentId == 0).Select(item => new TreeViewModel
            {
                id = item.MenuId + "",
                value = "",
                parentnodes = "0",
                checkstate = 0,
                img = item.Icon,
                text = item.MenuName,
                ChildNodes = sysMenu.Where(s => s.ParentId == item.MenuId).Select(items => new TreeViewModel
                {
                    id = items.MenuId + "",
                    value = "",
                    parentnodes = items.ParentId + "",
                    checkstate = 0,
                    img = items.Icon,
                    text = items.MenuName,
                    ChildNodes = sysMenu.Where(s => s.ParentId == items.MenuId).Select(button => new TreeViewModel
                    {
                        id = button.MenuId + "",
                        value = "",
                        parentnodes = button.ParentId + "",
                        checkstate = 0,
                        img = button.Icon,
                        text = button.MenuName
                    }).ToList()
                }).ToList()
            }).ToList();
        }
    }
}