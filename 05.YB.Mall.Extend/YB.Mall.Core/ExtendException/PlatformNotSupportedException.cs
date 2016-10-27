using YB.Mall.Extend.Helper;
using YB.Mall.Extend.Log;
namespace YB.Mall.Core.ExtendException
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PlatformNotSupportedException : YBMallException
    {
        public PlatformNotSupportedException(PlatformType platformType)
            : base("不支持" + platformType.ToDescription() + "平台")
        {
            Log.Info(this.Message, this);
        }
    }
}
