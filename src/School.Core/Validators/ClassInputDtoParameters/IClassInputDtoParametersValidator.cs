using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.ClassInputDtoParameters
{
    public interface IClassInputDtoParametersValidator
    {
        void ClassId(int classId, OperationResponseBase response, string lineWithError);

        void Teacher(string teacher, OperationResponseBase response, string lineWithError);

        void Course(string course, OperationResponseBase response, string lineWithError);

        void Shift(string shift, OperationResponseBase response, string lineWithError);

        void Date(DateTime startDate, DateTime endDate, OperationResponseBase response, string lineWithError);

        void Time(TimeSpan startTime, TimeSpan endTime, OperationResponseBase response, string lineWithError);
    }
}
