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
        /// <summary>
        /// EF 原生语法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IEnumerable<T> Add(IEnumerable<T> entity);
        /// <summary>
        /// EF 原生语法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(T entity);
        /// <summary>
        /// EF.Ext 语法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> filed);
        /// <summary>
        /// EF 原生语法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete(T entity);
        /// <summary>
        /// EF.Ext 语法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> predi);
        IQueryable<T> Query(Expression<Func<T, bool>> where);
        T Single(Expression<Func<T, bool>> where);
        jqGridPagerViewModel<T,dynamic> Pager<TKey>(Expression<Func<T, bool>> where, int page, int size,Expression<Func<T, TKey>> sort=null, bool desc = true);
        jqGridPagerViewModel<T, dynamic> Pager(PagerQueryModel query, Expression<Func<T, bool>> where);
    }

}
