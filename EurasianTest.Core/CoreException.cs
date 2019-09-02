using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core
{
    public sealed class CoreException : Exception
    {
        public CoreException(ResultCode resultCode)
        {
            this.Code = resultCode;
        }

        public ResultCode Code { get; } = ResultCode.Ok;
    }
}
