namespace YB.Mall.Core.Plugins
{
    using System;
    using System.Runtime.CompilerServices;
    public class Plugin<T> : PluginBase where T: IPlugin
    {
        public T Biz { get; set; }
    }
}

