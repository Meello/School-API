using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.InsertAndUpdate
{
    public interface IInsertAndUpdateValidator<TResponse>
        where TResponse : OperationResponseBase, new()
    {
        TResponse ValidateInsertAndUpdate(TeacherRequestData requestData);
    }
}
