using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.NullOrZero
{
    public interface IIsNullOrZeroValidator
    {
        bool IsNullOrZero(long? num, OperationResponseBase response, string fieldname);

        bool IsNullOrZero(int? num, OperationResponseBase response, string fieldname);
    }
}
