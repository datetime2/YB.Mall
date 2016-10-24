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
            var tree = new List<TreeSelectModel>();
            foreach (var item in grid.Where(s => s.ParentId == 0))
            {
                tree.Add(new TreeSelectModel
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
                    IsEnabled = item.IsEnabled
                });
                tree.AddRange(grid.Where(s => s.ParentId == item.MenuId).Select(items => new TreeSelectModel
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
                    IsEnabled = items.IsEnabled
                }));
            }
            select.rows = tree;
            return select;
        }
    }
}