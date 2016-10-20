using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using YB.Mall.Model.QueryModel;
using YB.Mall.Model.ViewModel;

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
        PagerViewModel<T> Pager<TKey>(Expression<Func<T, bool>> where, int page, int size,Expression<Func<T, TKey>> sort=null, bool desc = true);
        PagerViewModel<T> Pager<TKey>(PagerQueryModel<T, TKey> query);
    }

}
