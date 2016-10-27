namespace YB.Mall.Core.Plugins
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class PluginBase
    {
        protected PluginBase()
        {
        }

        public PluginInfo PluginInfo { get; set; }
    }
}

