using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Core.ExtendException
{
    public class InvalidPropertyException : YBMallException
    {
        public InvalidPropertyException()
        {
        }

        public InvalidPropertyException(string message)
            : base(message)
        {
        }

        public InvalidPropertyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
