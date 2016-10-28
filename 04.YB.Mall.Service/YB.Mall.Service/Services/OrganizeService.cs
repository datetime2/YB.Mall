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
    public class OrganizeService : IOrganizeService
    {
        private IOrganizeRepository repository;
        private IUnitOfWork unitOfWork;
        public OrganizeService(IOrganizeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public MenuSelectModel<OrganizeGridModel> OrganizeGrid(Model.QueryModel.MenuQueryModel query)
        {
            var select = new MenuSelectModel<OrganizeGridModel>();
            var predicate = PredicateBuilderUtility.True<Organize>();
            if (!string.IsNullOrWhiteSpace(query.keyword))
                predicate = predicate.And(s => s.OrganizeName.Contains(query.keyword));
            var grid = repository.GetMany(predicate);
            var tree = new List<OrganizeGridModel>();
            InitTree(0, grid, tree);
            select.rows = tree;
            return select;
        }

        private void InitTree(int parentId, IEnumerable<Organize> data, List<OrganizeGridModel> tree)
        {
            var menuInfos = data as IList<Organize> ?? data.ToList();
            var root = menuInfos.Where(s => s.ParentId == parentId);
            foreach (var item in root)
            {
                tree.Add(new OrganizeGridModel
                {
                    level = item.ParentId == 0 ? 0 : 1,
                    isLeaf = !data.Any(s => s.ParentId == item.OrganizeId),
                    parent = item.ParentId + "",
                    OrganizeId = item.OrganizeId,
                    ParentId = item.ParentId,
                    OrganizeName = item.OrganizeName,
                    OrganizeEnCode = item.OrganizeEnCode,
                    IsEnabled = item.IsEnabled,
                    OrganizeType = item.OrganizeType.ToDescription()
                });
                InitTree(item.OrganizeId, menuInfos, tree);
            }
        }

        public List<TreeSelectModel> OrganizeTree(Model.QueryModel.MenuQueryModel query)
        {
            var tree = new List<TreeSelectModel>();
            var predicate = PredicateBuilderUtility.True<Organize>();
            if (!string.IsNullOrWhiteSpace(query.keyword))
                predicate = predicate.And(s => s.OrganizeName.Contains(query.keyword));
            var grid = repository.GetMany(predicate);
            foreach (var item in grid.Where(s => s.ParentId == 0))
            {
                tree.Add(new TreeSelectModel
                {
                    id = item.OrganizeId,
                    parentId = item.ParentId,
                    text = item.OrganizeName
                });
                tree.AddRange(grid.Where(s => s.ParentId == item.OrganizeId).Select(items => new TreeSelectModel
                {
                    id = items.OrganizeId,
                    parentId = items.ParentId,
                    text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + items.OrganizeName
                }));
            }
            return tree;
        }

        public Model.Organize InitForm(int menuId)
        {
            return repository.Single(s => s.OrganizeId.Equals(menuId));
        }

        public bool SubmitForm(Model.Organize orga, int? keyValue)
        {
            if (keyValue.HasValue)
                return repository.Update(s => s.OrganizeId == keyValue, u => new Organize
                {
                    OrganizeName = orga.OrganizeName,
                    OrganizeEnCode = orga.OrganizeEnCode,
                    OrganizeType = orga.OrganizeType,
                    IsEnabled = orga.IsEnabled,
                    ParentId = orga.ParentId,
                    ManagerName = orga.ManagerName,
                    Phone = orga.Phone,
                    Email = orga.Email,
                    Address = orga.Address,
                    Description = orga.Description
                });
            else
            {
                repository.Add(orga);
                unitOfWork.SaveChanges();
                return orga.OrganizeId > 0;
            }
        }

        public bool Remove(System.Linq.Expressions.Expression<System.Func<Model.Organize, bool>> where)
        {
            throw new System.NotImplementedException();
        }
    }
}