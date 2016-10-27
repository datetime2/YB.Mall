using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Mall.Extend.Log;

namespace YB.Mall.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private MallContext dbContext;
        private readonly IDatabaseFactory dbFactory;
        protected MallContext DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get();
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var error = string.Empty;
                foreach (var item2 in dbex.EntityValidationErrors.SelectMany(item => item.ValidationErrors))
                {
                    error = string.Format("{0}:{1}\r\n", item2.PropertyName, item2.ErrorMessage);
                }
                Log.Error(error);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
