using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace YB.Mall.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T Add(T entity);
        void Update(T entity);
        bool Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> filed);
        void Delete(T entity);
        bool Delete(Expression<Func<T, bool>> predi);
        IQueryable<T> Query(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where);

        IQueryable<T> Paging(IQueryable<T> entities, Expression<Func<T, bool>> where, int page, int size,
            out int total);
        IQueryable<T> Paging<T, TKey>(IQueryable<T> entities, Expression<Func<T, bool>> where, int page, int size,
            out int total, Expression<Func<T, TKey>> sort, bool desc = true);
    }

}
