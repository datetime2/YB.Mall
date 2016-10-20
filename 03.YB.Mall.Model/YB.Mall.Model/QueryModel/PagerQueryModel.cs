using System;
using System.Linq.Expressions;

namespace YB.Mall.Model.QueryModel
{
    /// <summary>
    /// 分页条件
    /// </summary>
    /// <typeparam name="T">模型</typeparam>
    /// <typeparam name="TKey">排序字段</typeparam>
    public class PagerQueryModel<T,TKey> where T : class
    {
        public PagerQueryModel()
        {
            this.Page = 1;
            this.Size = 50;
            this.Sort = null;
        }
        /// <summary>
        /// 条件
        /// </summary>
        public Expression<Func<T, bool>> Where { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// 分页数
        /// </summary>
        public int? Size { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public Expression<Func<T, TKey>> Sort { get; set; }
        /// <summary>
        /// 是否倒序
        /// </summary>
        public bool Desc { get; set; }
    }
}