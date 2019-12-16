using School.Core.Models;
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

        public void ValidateMaxLength(string value, int maxlength, OperationResponseBase response, string fieldname)
        {
            if (value != null && value.Length > maxlength)
            {
                response.Errors.Add(new OperationError("004", $"{fieldname} lenght don't supported! Limit: {maxlength} caracters"));
            }
        }

        //Tentar usar foreach para comparar gender com uma lista de gender aceitos
        public void ValidateGender(char? gender, OperationResponseBase response, string fieldname)
        {
            if (gender != null && gender != '\u0000' && gender != 'F' && gender != 'M')
            {
                response.Errors.Add(new OperationError("005", $"Invalid {fieldname}! Choose M or F"));
            }
        }

        public bool ValidateGender(char? gender)
        {
            if (gender != null && gender != '\u0000' && gender != 'F' && gender != 'M')
            {
                return false;
            }

            return true;
        }


        //Tentar usar foreach para comparar level com uma lista de level aceitos
        public void ValidateLevel(char? level, OperationResponseBase response, string fieldname)
        {
            if (level != null && level != '\u0000' && level != 'J' && level != 'P' && level != 'S')
            {
                response.Errors.Add(new OperationError("006", $"Invalid {fieldname}! Choose J or P or S"));
            }
        }

        public bool ValidateLevel(char? level)
        {
            if (level != null && level != '\u0000' && level != 'J' && level != 'P' && level != 'S')
            {
                return false;
            }

            return true;
        }

        public void ValidateMinMaxSalary(decimal? salary, decimal minsalary, decimal maxsalary, OperationResponseBase response, string fieldname)
        {
            if (salary != null && salary != decimal.Zero && salary < minsalary || salary > maxsalary)
            {
                response.Errors.Add(new OperationError("007", $"Value of {fieldname} don't accepted! Choose a value between {minsalary} and {maxsalary}"));
            }
        }

        public void ValidateAdmitionDate(DateTime? admitionDate, OperationResponseBase response, string fieldname)
        {
            if (admitionDate != null && admitionDate != DateTime.MinValue && admitionDate > DateTime.Today)
            {
                response.Errors.Add(new OperationError("008", $"{fieldname} can't be bigger than today"));
            }
        }

        public bool ValidateUpperCase(char? c, OperationResponseBase response, string fieldname)
        {
            if (char.IsUpper(c.Value) == false)
            {
                response.Errors.Add(new OperationError("018", $"{fieldname} must be in upper case"));

                return false;
            }

            return true;
        }

        public bool ValidateUpperCase(char? c)
        {
            if (char.IsUpper(c.Value) == false)
            {
                return false;
            }

            return true;
        }

        public void ValidatePage(long pageSize, OperationResponseBase response)
        {
            if (pageSize > ModelConstants.Teacher.MaxTeachersPerPage)
            {
                response.Errors.Add(new OperationError("015", "Number of teachers exceeded the limit"));
            }
        }
    }
}
