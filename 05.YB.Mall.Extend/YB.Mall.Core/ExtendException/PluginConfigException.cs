using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Core.ExtendException
{
    /// <summary>
    /// 插件配置文件异常
    /// </summary>
    public class PluginConfigException : Exception
    {
        public PluginConfigException(string message)
            : base(message)
        {

        }
    }
}
