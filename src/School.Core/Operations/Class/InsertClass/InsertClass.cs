using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.Class.InsertClass
{
    public class InsertClass : OperationBase<InsertClassRequest, InsertClassResponse>, IInsertClass
    {
        protected override InsertClassResponse ProcessOperation(InsertClassRequest request)
        {
            throw new NotImplementedException();
        }

        protected override InsertClassResponse ValidateOperation(InsertClassRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
