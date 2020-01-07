using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.NullOrZero
{
    public interface IIsNullOrZeroValidator
    {
        bool Execute(long? num, OperationResponseBase response, string fieldname);

        bool Execute(int? num, OperationResponseBase response, string fieldname);

        bool Execute(string str, OperationResponseBase response, string fieldname);

        bool Execute(DateTime? date, OperationResponseBase response, string fieldname);

        bool Execute(TimeSpan? time, OperationResponseBase response, string fieldname);
    }
}
