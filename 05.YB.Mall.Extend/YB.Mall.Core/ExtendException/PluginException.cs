using YB.Mall.Extend.Log;

namespace YB.Mall.Core.Plugins
{
    using YB.Mall.Core.ExtendException;
    using System;
    public class PluginException : YBMallException
    {
        public PluginException(string message) : base(message)
        {
            Log.Info(message);
        }
    }
}

