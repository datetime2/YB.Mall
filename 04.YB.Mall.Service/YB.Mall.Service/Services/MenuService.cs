using System;
using System.Collections.Generic;
using System.Linq;
using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;
using YB.Mall.Extend.Linq;
using YB.Mall.Model;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;

namespace YB.Mall.Service
{
    public class MenuService : IMenuService
    {
        private IMenuRepository repository;
        private IUnitOfWork unitOfWork;
        public MenuService(IMenuRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public MenuSelectModel MenuGrid(MenuQueryModel query)
        {
            var select = new MenuSelectModel();
            var predicate = PredicateBuilderUtility.True<MenuInfo>();
            if (!string.IsNullOrWhiteSpace(query.keyword))
                predicate = predicate.And(s => s.MenuName.Contains(query.keyword));
            var grid = repository.GetMany(predicate);
            var tree = new List<TreeGridModel>();
            foreach (var item in grid.Where(s => s.ParentId == 0))
            {
                tree.Add(new TreeGridModel
                {
                    level = 0,
                    isLeaf = false,
                    parent = "0",
                    MenuId = item.MenuId,
                    ParentId = item.ParentId,
                    UrlPath = item.UrlPath,
                    Icon = item.Icon,
                    MenuName = item.MenuName,
                    Target = item.Target,
                    IsButton = item.IsButton,
                    IsMenu = item.IsMenu,
                    IsEnabled = item.IsEnabled,
                    Remark = item.Remark
                });
                tree.AddRange(grid.Where(s => s.ParentId == item.MenuId).Select(items => new TreeGridModel
                {
                    level = 1,
                    isLeaf = true,
                    parent = items.ParentId + "",
                    MenuId = items.MenuId,
                    ParentId = items.ParentId,
                    UrlPath = items.UrlPath,
                    Icon = items.Icon,
                    MenuName = items.MenuName,
                    Target = items.Target,
                    IsButton = items.IsButton,
                    IsMenu = items.IsMenu,
                    IsEnabled = items.IsEnabled,
                    Remark = items.Remark
                }));
            }
            select.rows = tree;
            return select;
        }


        public List<TreeSelectModel> MenuTree(MenuQueryModel query)
        {
            var tree = new List<TreeSelectModel>();
            var predicate = PredicateBuilderUtility.True<MenuInfo>();
            if (!string.IsNullOrWhiteSpace(query.keyword))
                predicate = predicate.And(s => s.MenuName.Contains(query.keyword));
            var grid = repository.GetMany(predicate);
            foreach (var item in grid.Where(s => s.ParentId == 0))
            {
                tree.Add(new TreeSelectModel
                {
                    id = item.MenuId,
                    parentId = item.ParentId,
                    text = item.MenuName
                });
                tree.AddRange(grid.Where(s => s.ParentId == item.MenuId).Select(items => new TreeSelectModel
                {
                    id = items.MenuId,
                    parentId = items.ParentId,
                    text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + items.MenuName
                }));
            }
            return tree;
        }

        public MenuInfo SingleMenu(int menuId)
        {
            return repository.Single(s => s.MenuId.Equals(menuId));
        }

        public bool SubmitForm(MenuInfo menu, int? keyValue)
        {
            if (keyValue.HasValue)
                return repository.Update(s => s.MenuId == keyValue, u => new MenuInfo
                {
                    MenuName = menu.MenuName,
                    Icon = menu.Icon,
                    IsMenu = menu.IsMenu,
                    UrlPath = menu.UrlPath,
                    IsButton = menu.IsButton,
                    IsEnabled = menu.IsEnabled,
                    ParentId = menu.ParentId,
                    LastUpdTime = DateTime.Now,
                    Target = menu.Target,
                    Sort = menu.Sort,
                    Remark = menu.Remark
                });
            else
            {
                repository.Add(menu);
                unitOfWork.SaveChanges();
                return menu.MenuId > 0;
            }
        }
    }
}