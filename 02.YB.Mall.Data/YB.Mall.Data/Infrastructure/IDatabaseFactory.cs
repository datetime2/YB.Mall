using System;
using YB.Mall.Data;

namespace YB.Mall.Data.Infrastructure 
{
    public interface IDatabaseFactory : IDisposable
    {
        MallContext Get();
    }
}
