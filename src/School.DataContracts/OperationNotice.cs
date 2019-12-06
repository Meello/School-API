using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts
{
    public sealed class OperationNotification
    {
        public OperationNotification(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public string Code { get; }

        public string Message {get;}
    }
}
