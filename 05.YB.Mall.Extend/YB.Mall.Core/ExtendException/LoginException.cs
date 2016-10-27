using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YB.Mall.Core.ExtendException
{
    public class LoginException:YBMallException
    {
        /// <summary>
        /// 错误类型
        /// </summary>
        public enum ErrorTypes
        {
            UsernameError,
            PasswordError,
            CheckCodeError
        }

        ErrorTypes _errrorType;
        /// <summary>
        /// 错误类型
        /// </summary>
        public ErrorTypes ErrorType { get { return _errrorType; } }
        public LoginException(string msg, ErrorTypes errorType)
            : base(msg)
        {
            _errrorType = errorType;
        }
    }
}
