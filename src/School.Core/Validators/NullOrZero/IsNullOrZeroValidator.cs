using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators
{
    public class IsNullOrZeroValidator
    {
        public bool IsNullOrZero(long? num, OperationResponseBase response, string fieldname)
        {
            if (num == 0 || num == null)
            {
                response.AddError("002", $"{fieldname} can't be null or zero");

                return true;
            }

            return false;
        }

        public bool IsNullOrZero(int? num, OperationResponseBase response, string fieldname)
        {
            if (num == 0 || num == null)
            {
                response.AddError("002", $"{fieldname} can't be null or zero");

                return true;
            }

            return false;
        }
    }
}
