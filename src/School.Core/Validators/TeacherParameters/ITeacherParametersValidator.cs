using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.ValidateTeacherParameters
{
    public interface ITeacherParametersValidator
    {
        void ValidateTeacherId(long? value, OperationResponseBase response);

        void ValidateName(string name, OperationResponseBase response);

        void ValidateGender(char? gender, OperationResponseBase response);

        void ValidateLevel(char? level, OperationResponseBase response);

        void ValidateSalary(decimal? salary, OperationResponseBase response, string filedname);

        void ValidateAdmitionDate(DateTime? AdmitionDate, OperationResponseBase response, string filedname);

        bool IsGenderValid(char? gender);

        void ValidatePageSize(int? pageSize, OperationResponseBase response);

        void ValidatePageNumber(int? pageNumber, OperationResponseBase response);
    }
}
