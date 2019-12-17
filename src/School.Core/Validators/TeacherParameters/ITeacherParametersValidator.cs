using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.ValidateTeacherParameters
{
    public interface ITeacherParametersValidator
    {
        void ValidateTeacherId(long? value, OperationResponseBase response, string fieldName);

        void ValidateName(string name, OperationResponseBase response, string fieldName);

        void ValidateGender(char? gender, OperationResponseBase response, string fieldname);

        void ValidateLevel(char? level, OperationResponseBase response, string fieldname);

        void ValidateSalary(decimal? salary, OperationResponseBase response, string fieldname);

        void ValidateAdmitionDate(DateTime? AdmitionDate, OperationResponseBase response, string fieldname);

        bool ValidateGender(char? gender);

        bool ValidateLevel(char? level);

        void ValidatePageSize(int pageSize, OperationResponseBase response);

        void ValidatePageNumber(int pageNumber, OperationResponseBase response);
    }
}
