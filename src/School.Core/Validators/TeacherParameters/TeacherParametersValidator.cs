using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.ValidateTeacherParameters
{
    public class TeacherParametersValidator : ITeacherParametersValidator
    {
        public void ValidateNullOrZero(long? value, OperationResponseBase response, string fieldName)
        {
            if (value == null || value == 0)
            {
                response.Errors.Add(new OperationError("002", $"Field {fieldName} can't be null or zero"));
            }
        }

        public void ValidateNullOrZero(string value, OperationResponseBase response, string fieldName)
        {
            if (value == null)
            {
                response.Errors.Add(new OperationError("002", $"Field {fieldName} can't be null or zero"));
            }
        }

        public void ValidateNullOrZero(DateTime? value, OperationResponseBase response, string fieldName)
        {
            if (value == null || value == DateTime.MinValue)
            {
                response.Errors.Add(new OperationError("002", $"Field {fieldName} can't be null or zero"));
            }
        }

        public void ValidateNullOrZero(char? value, OperationResponseBase response, string fieldName)
        {
            if (value == null || value == '\u0000')
            {
                response.Errors.Add(new OperationError("002", $"Field {fieldName} can't be null or zero"));
            }
        }

        public void ValidateNullOrZero(decimal? value, OperationResponseBase response, string fieldName)
        {
            if (value == null || value == decimal.Zero)
            {
                response.Errors.Add(new OperationError("002", $"Field {fieldName} can't be null or zero"));
            }
        }

        public void ValidateMaxLength(string value, int maxlength, OperationResponseBase response)
        {
            if (value != null && value.Length > maxlength)
            {
                response.Errors.Add(new OperationError("004", "Name lenght don't supported! Limit: 32 caracters"));
            }
        }

        public void ValidateGender(char? gender, OperationResponseBase response)
        {
            if (gender != null && gender != '\u0000' && gender != 'F' && gender != 'M')
            {
                response.Errors.Add(new OperationError("005", "Invalid Gender! Choose M or F"));
            }
        }

        public void ValidateLevel(char? level, OperationResponseBase response)
        {
            if (level != null && level != '\u0000' && level != 'J' && level != 'P' && level != 'S')
            {
                response.Errors.Add(new OperationError("006", "Invalid Level! Choose J or P or S"));
            }
        }

        public void ValidateMinMaxSalary(decimal? salary, decimal minsalary, decimal maxsalary, OperationResponseBase response)
        {
            if (salary != null && salary != decimal.Zero && salary < minsalary || salary > maxsalary)
            {
                response.Errors.Add(new OperationError("007", "Value don't accepted! Choose some value between 1000 and 10000"));
            }
        }

        public void ValidateAdmitionDate(DateTime? admitionDate, OperationResponseBase response)
        {
            if (admitionDate != null && admitionDate != DateTime.MinValue && admitionDate > DateTime.Today)
            {
                response.Errors.Add(new OperationError("008", "Admition date can't be bigger than today"));
            }
        }

        public char ValidateUpperCase(char? c)
        {
            if (char.IsUpper(c.Value) == false)
            {
                return char.ToUpper(c.Value);
            }

            return c.Value;
        }
    }
}
