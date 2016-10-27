using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace YB.Mall.Core.ExtendException
{
    /// <summary>
    /// YB.Mall 自定义异常错误处理类
    /// </summary>
    public class YBMallException : Exception
    {
        public YBMallException() { }
        /// <summary>
        /// YB.Mall 自定义异常错误处理类
        /// </summary>
        /// <param name="message">错误提示内容</param>
        public YBMallException(string message)
            : base(message)
        {

        }
        public YBMallException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
