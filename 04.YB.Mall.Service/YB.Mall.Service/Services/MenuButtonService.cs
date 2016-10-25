using System;
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
    public class MenuButtonService : IMenuButtonService
    {
        private IMenuButtonRepository repository;
        private IUnitOfWork unitOfWork;
        public MenuButtonService(IMenuButtonRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public jqGridPagerViewModel<MenuButtonInfo, dynamic> ButtonGrid(MenuButtonQueryModel query)
        {
            var predicate = PredicateBuilderUtility.True<MenuButtonInfo>();
            if (query.menuId.HasValue)
                predicate = predicate.And(s => s.MenuId == query.menuId);
            var grid = repository.Pager(query, predicate);
            return new jqGridPagerViewModel<MenuButtonInfo, dynamic>
            {
                rows = grid.rows.Select(s => new
                {
                    ButtonId = s.ButtonId,
                    ButtonName = s.ButtonName,
                    ElementId = s.ElementId,
                    Event = s.Event,
                    IsEnabled = s.IsEnabled,
                    Location = s.Location
                }),
                size = grid.size,
                page = grid.page,
                records = grid.records
            };
        }

        public MenuButtonInfo SingleButton(System.Linq.Expressions.Expression<System.Func<MenuButtonInfo, bool>> where)
        {
            return repository.Single(where);
        }
        public bool SubmitForm(MenuButtonInfo button, int? keyValue)
        {
            if (keyValue.HasValue)
                return repository.Update(s => s.ButtonId == keyValue, u => new MenuButtonInfo
                {
                    ButtonName = button.ButtonName,
                    Icon = button.Icon,
                    ElementId = button.ElementId,
                    Event = button.Event,
                    IsEnabled = button.IsEnabled,
                    Sort = button.Sort,
                    Location = button.Location
                });
            else
            {
                repository.Add(button);
                unitOfWork.SaveChanges();
                return button.ButtonId > 0;
            }
        }
        public bool Remove(System.Linq.Expressions.Expression<Func<MenuButtonInfo, bool>> where)
        {
            return repository.Delete(where);
        }
    }
}