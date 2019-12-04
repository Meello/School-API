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

        void ValidateMaxLength(string name, int maxlength, OperationResponseBase response);

        void ValidateGender(char? gender, OperationResponseBase response);

        void ValidateLevel(char? level, OperationResponseBase response);

        void ValidateMinMaxSalary(decimal? salary, decimal minsalary, decimal maxsalary, OperationResponseBase response);

        void ValidateAdmitionDate(DateTime? admitionDate, OperationResponseBase response);

        char ValidateUpperCase(char? c);
    }
}
