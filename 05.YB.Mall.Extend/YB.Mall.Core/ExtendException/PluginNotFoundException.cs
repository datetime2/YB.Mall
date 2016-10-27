namespace YB.Mall.Core.Plugins
{
    using System;

    public class PluginNotFoundException : PluginException
    {
        public PluginNotFoundException(string pluginId) : base("未找到插件" + pluginId)
        {

        }
    }
}

