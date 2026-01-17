using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizFlowControl
{
    public class DBException : Exception
    {
        public String ErrorCode { get;}

        public DBException(string code, string message) : base(message)
        {
            this.ErrorCode = code;
        }

        public const string ERROR_CODE_NOT_CONNECTED = "DB001";
    }
}
