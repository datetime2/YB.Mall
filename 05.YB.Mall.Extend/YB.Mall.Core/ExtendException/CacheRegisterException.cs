using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Core.ExtendException
{
    public class CacheRegisterException : YBMallException
    {
        public CacheRegisterException()
        {
        }
        public CacheRegisterException(string message)
            : base(message)
        {
        }

        public CacheRegisterException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
