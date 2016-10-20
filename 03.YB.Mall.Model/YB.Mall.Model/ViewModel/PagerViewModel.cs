using System.Collections.Generic;
using System.Linq;

namespace YB.Mall.Model.ViewModel
{
    /// <summary>
    /// 分页实体
    /// </summary>
    public class PagerViewModel<T> where T:class 
    {
        public PagerViewModel()
        {
            this.Total = 0;
        }
        /// <summary>
        /// 数据集合
        /// </summary>
        public IEnumerable<T> Data { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int? Total { get; set; }
    }
}