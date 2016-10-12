using YB.Mall.Data;

namespace YB.Mall.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MallContext dataContext;
        public MallContext Get()
        {
            return dataContext ?? (dataContext = new MallContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
