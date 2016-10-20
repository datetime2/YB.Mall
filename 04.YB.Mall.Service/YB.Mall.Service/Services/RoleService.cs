using System.Collections.Generic;
using System.Linq;
using YB.Mall.Data.Infrastructure;
using YB.Mall.Data.Repositories;
using YB.Mall.Model.ViewModel;

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
            var grid = menuRepository.Query(s => s.Status == 0);
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
    }
}