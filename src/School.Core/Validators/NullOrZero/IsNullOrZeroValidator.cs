using School.Core.Validators.NullOrZero;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.NullOrZero
{
    public class IsNullOrZeroValidator : IIsNullOrZeroValidator
    {
        public bool Execute(long? num, OperationResponseBase response, string fieldname)
        {
            if (num == 0 || num == null)
            {
                response.AddError("002",$"{fieldname} can't be null or zero.");

                return true;
            }

            return false;
        }

        public bool Execute(int? num, OperationResponseBase response, string fieldname)
        {
            if (num == 0 || num == null)
            {
                response.AddError("002",$"{fieldname} can't be null or zero.");

                return true;
            }

            return false;
        }

        public bool Execute(DateTime? date, OperationResponseBase response, string fieldname)
        {
            if (date == null || date == DateTime.MinValue)
            {
                response.AddError("002",$"{fieldname} can't be null or zero.");
             
                return true;
            }

            return false;
        }

        public bool Execute(TimeSpan? time, OperationResponseBase response, string fieldname)
        {
            if (time == null || time == TimeSpan.Zero)
            {
                response.AddError("002",$"{fieldname} can't be null or zero.");
                
                return true;
            }

            return false;
        }

        public bool Execute(string str, OperationResponseBase response, string fieldname)
        {
            if(!string.IsNullOrWhiteSpace(str))
            {
                response.AddError("002", $"{fieldname} can't be null or zero.");

                return true;
            }

            return false;
        }
    }
}
