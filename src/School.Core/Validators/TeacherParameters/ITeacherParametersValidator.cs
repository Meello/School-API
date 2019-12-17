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

        void ValidateMaxLength(string value, int maxlength, OperationResponseBase response, string fieldname);

        void ValidateGender(char? gender, OperationResponseBase response, string fieldname);

        bool ValidateGender(char? gender);

        void ValidateLevel(char? level, OperationResponseBase response, string fieldname);

        bool ValidateLevel(char? level);

        void ValidateMinMaxSalary(decimal? salary, decimal minsalary, decimal maxsalary, OperationResponseBase response, string fieldname);

        void ValidateAdmitionDate(DateTime? admitionDate, OperationResponseBase response, string fieldname);

        bool ValidateUpperCase(char? c, OperationResponseBase response, string fieldname);

        bool ValidateUpperCase(char? c);

        void ValidatePage(int pageNumber, int pageSize, OperationResponseBase response);
    }
}
