using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Core.ExtendException
{
    public class AOPProxyException : YBMallException
    {
        public AOPProxyException() { }
        public AOPProxyException(string message) : base(message) { }
        public AOPProxyException(string message, Exception inner) : base(message, inner) { }
    }
}
