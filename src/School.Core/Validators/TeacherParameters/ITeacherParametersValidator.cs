using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.ValidateTeacherParameters
{
    public interface ITeacherParametersValidator
    {
        void ValidateNullOrZero(long? value, OperationResponseBase response, string fieldName);
        
        void ValidateNullOrZero(string value, OperationResponseBase response, string fieldName);

        void ValidateNullOrZero(decimal? value, OperationResponseBase response, string fieldName);
        
        void ValidateNullOrZero(char? value, OperationResponseBase response, string fieldName);

        void ValidateNullOrZero(DateTime? value, OperationResponseBase response, string fieldName);

        void ValidateMaxLength(string name, OperationResponseBase response);

        void ValidateGender(char? gender, OperationResponseBase response);

        void ValidateLevel(char? level, OperationResponseBase response);

        void ValidateSalary(decimal? salary, OperationResponseBase response);

        void ValidateAdmitionDate(DateTime? admitionDate, OperationResponseBase response);
    }
}
