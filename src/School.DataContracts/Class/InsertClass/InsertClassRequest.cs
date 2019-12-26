using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Class.InsertClass
{
    public class InsertClassRequest : OperationRequestBase
    {
        public InsertClassRequest(InsertClassRequestData requestData)
        {
            Data = requestData;
        }

        public InsertClassRequestData Data { get; }
    }
}
