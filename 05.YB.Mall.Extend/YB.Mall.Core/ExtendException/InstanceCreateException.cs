using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Core.ExtendException
{
    public class InstanceCreateException : YBMallException
    {
        public InstanceCreateException()
        {
        }
        public InstanceCreateException(string message)
            : base(message)
        {
        }

        public InstanceCreateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
