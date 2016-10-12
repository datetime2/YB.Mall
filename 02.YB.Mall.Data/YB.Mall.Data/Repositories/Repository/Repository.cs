using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using YB.Mall.Data.Infrastructure;
using EntityFramework.Extensions;
namespace YB.Mall.Data.Repositories
{
    public abstract class Repository<T> where T : class, new()
    {
        private MallContext _dataContext;
        private readonly IDbSet<T> _dbset;
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
            return _dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where);
        }
        public virtual IQueryable<T> Paging(IQueryable<T> entities, Expression<Func<T, bool>> where, int page, int size, out int total)
        {
            total = entities.Count(where);
            return entities.Where(where).Skip((page - 1) * size).Take(size);
        }

        public virtual IQueryable<T> Paging<T, TKey>(IQueryable<T> entities, Expression<Func<T, bool>> where, int page,
            int size, out int total, Expression<Func<T, TKey>> sort, bool desc = true)
        {
            total = entities.Count(where);
            var newEntities = !desc
                ? entities.Where(@where).OrderBy(sort).Skip((page - 1)*size).Take(size)
                : entities.Where(@where).OrderByDescending(sort).Skip((page - 1)*size).Take(size);
            return newEntities;
        }
    }
}
