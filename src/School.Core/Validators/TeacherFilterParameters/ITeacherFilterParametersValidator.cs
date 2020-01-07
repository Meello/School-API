using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.TeacherFilterParameters
{
    public interface ITeacherFilterParametersValidator
    {
        void ValidateGenders(List<char> genders, OperationResponseBase response);

        void ValidateLevelIds(List<char> levels, OperationResponseBase response);

        void ValidateAdmitionDate(DateTime? minAdmitionDate, DateTime? maxAdmitionDate, OperationResponseBase response);

        void ValidateSalary(decimal? minSalary, decimal? maxSalary, OperationResponseBase response);
    }
}
