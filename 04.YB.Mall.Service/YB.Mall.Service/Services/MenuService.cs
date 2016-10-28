using System;
using System.Collections.Generic;
using System.Linq;
using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;
using YB.Mall.Extend.Helper;
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

        public MenuSelectModel<TreeGridModel> MenuGrid(MenuQueryModel query)
        {
            var select = new MenuSelectModel<TreeGridModel>();
            var predicate = PredicateBuilderUtility.True<MenuInfo>();
            if (!string.IsNullOrWhiteSpace(query.keyword))
                predicate = predicate.And(s => s.MenuName.Contains(query.keyword));
            var grid = repository.GetMany(predicate);
            var tree = new List<TreeGridModel>();
            InitTree(0, grid, tree);
            select.rows = tree;
            return select;
        }

        private void InitTree(int parentId, IEnumerable<MenuInfo> data, List<TreeGridModel> tree)
        {
            var menuInfos = data as IList<MenuInfo> ?? data.ToList();
            var root = menuInfos.Where(s => s.ParentId == parentId);
            foreach (var item in root)
            {
                tree.Add(new TreeGridModel
                {
                    level = item.ParentId == 0 ? 0 : 1,
                    isLeaf = !data.Any(s => s.ParentId == item.MenuId),
                    parent = item.ParentId + "",
                    MenuId = item.MenuId,
                    ParentId = item.ParentId,
                    UrlPath = item.UrlPath,
                    Icon = item.Icon,
                    MenuName = item.MenuName,
                    Target = item.Target,
                    IsEnabled = item.IsEnabled,
                    Remark = item.Remark,
                    ElementId = item.ElementId,
                    Event = item.Event,
                    MenuType = item.MenuType.ToDescription()
                });
                InitTree(item.MenuId, menuInfos, tree);
            }
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

        public MenuInfo InitForm(int menuId)
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
                    UrlPath = menu.UrlPath,
                    IsEnabled = menu.IsEnabled,
                    ParentId = menu.ParentId,
                    LastUpdTime = DateTime.Now,
                    Target = menu.Target,
                    Sort = menu.Sort,
                    Remark = menu.Remark,
                    ElementId = menu.ElementId,
                    Event = menu.Event,
                    MenuType = menu.MenuType
                });
            else
            {
                repository.Add(menu);
                unitOfWork.SaveChanges();
                return menu.MenuId > 0;
            }
        }
        public bool Remove(System.Linq.Expressions.Expression<Func<MenuInfo, bool>> where)
        {
            return repository.Delete(where);
        }
    }
}