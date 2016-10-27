namespace YB.Mall.Core.Plugins
{
    using System;

    public interface IPlugin
    {
        void CheckCanEnable();

        string WorkDirectory { set; }
    }
}

