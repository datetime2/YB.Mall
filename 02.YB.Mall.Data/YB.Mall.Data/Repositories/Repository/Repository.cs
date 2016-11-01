using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Utilities;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using YB.Mall.Data.Infrastructure;
using EntityFramework.Extensions;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;
using YB.Mall.Extend.Linq;
using System.Data.Entity.Utilities;

namespace YB.Mall.Data.Repositories
{
    public abstract class Repository<T> where T : class, new()
    {
        private MallContext _dataContext;
        private readonly DbSet<T> _dbset;

        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<T>();
        }

        private IDatabaseFactory DatabaseFactory
        {
            get;
            set;
        }

        private MallContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
        public virtual T Add(T entity)
        {
            _dbset.Add(entity);
            return entity;
        }

        public virtual IEnumerable<T> Add(IEnumerable<T> entity)
        {
            _dbset.AddRange(entity);
            return entity;
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual bool Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> filed)
        {
            return _dbset.Where(where).Update(filed) > 0;
        }
        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
        public virtual bool Delete(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).Delete() > 0;
        }
        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }
        public virtual T Single(Expression<Func<T, bool>> where)
        {
            return _dbset.FirstOrDefault(where);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset;
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey">排序字段</typeparam>
        /// <param name="where">条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">分页数</param>
        /// <param name="sort">排序</param>
        /// <param name="desc">倒序</param>
        /// <returns></returns>
        public virtual jqGridPagerViewModel<T, dynamic> Pager<TKey>(Expression<Func<T, bool>> where, int page,
            int size, Expression<Func<T, TKey>> sort = null, bool desc = true)
        {
            var entities = _dbset.Where(where);
            return new jqGridPagerViewModel<T, dynamic>
            {
                records = entities.Count(),
                page = page,
                size = size,
                rows = sort == null
                    ? entities.Skip((page - 1) * size).Take(size)
                    : (!desc
                        ? entities.OrderBy(sort).Skip((page - 1) * size).Take(size)
                        : entities.OrderByDescending(sort).Skip((page - 1) * size).Take(size))
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual jqGridPagerViewModel<T, dynamic> Pager(PagerQueryModel query, Expression<Func<T, bool>> where)
        {
            var entities = _dbset.Where(where);
            return new jqGridPagerViewModel<T, dynamic>
            {
                records = entities.Count(),
                page = query.page.Value,
                size = query.rows,
                rows = string.IsNullOrEmpty(query.sidx)
                    ? entities.Skip((query.page.Value - 1) * query.rows.Value).Take(query.rows.Value)
                    : (query.sord == "asc"
                        ? entities.OrderBy(query.sidx)
                            .Skip((query.page.Value - 1) * query.rows.Value)
                            .Take(query.rows.Value)
                        : entities.OrderBy(query.sidx, true)
                            .Skip((query.page.Value - 1) * query.rows.Value)
                            .Take(query.rows.Value))
            };
        }
    }
}
