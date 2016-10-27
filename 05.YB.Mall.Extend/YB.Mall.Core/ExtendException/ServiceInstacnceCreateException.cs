using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Core.ExtendException
{
    public class ServiceInstacnceCreateException:YBMallException
    {
        public ServiceInstacnceCreateException() { }
        public ServiceInstacnceCreateException(string message) : base(message) { }
        public ServiceInstacnceCreateException(string message, Exception inner) : base(message, inner) { }
    }
}
