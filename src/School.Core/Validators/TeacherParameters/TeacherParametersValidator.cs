using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using School.Core.Repositories;

namespace School.Core.Validators.ValidateTeacherParameters
{
    public class TeacherParametersValidator : ITeacherParametersValidator
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherParametersValidator(ITeacherRepository teacherRepository)
        {
            this._teacherRepository = teacherRepository;
        }

        public void ValidateTeacherId(long? value, OperationResponseBase response, string fieldname)
        {
            if (value == null || value == 0)
            {
                response.AddError("002", $"Field {fieldname} can't be null or zero");
            }
        }

        public void ValidateName(string name, OperationResponseBase response, string fieldname)
        {
            if (string.IsNullOrEmpty(name))
            {
                response.AddError("002", $"Field {fieldname} can't be null or zero");
            }
            else if (name.Length > ModelConstants.Teacher.NameMaxLength)
            {
                response.AddError("004", $"{fieldname} lenght don't supported! Limit: {ModelConstants.Teacher.NameMaxLength} caracters");
            }
            else if (Regex.IsMatch(name, @"[^a-zA-Z]"))
            {
                response.AddError("020",$"{fieldname} can't be specials characters");
            }
        }

        public void ValidateGender(char? gender, OperationResponseBase response, string fieldname)
        {
            if(gender == null || gender == '\u0000')
            {
                response.AddError("002", $"Field {fieldname} can't be null or zero");
            }
            else if(!char.IsUpper(gender.Value))
            {
                response.Errors.Add(new OperationError("018", $"{fieldname} must be in upper case"));
            }
            else if (gender != null && gender != '\u0000' && gender != 'F' && gender != 'M')
            {
                response.AddError("005", $"Invalid {fieldname}! Choose M or F");
            }
        }

        public void ValidateLevel(char? level, OperationResponseBase response, string fieldname)
        {
            if (level == null || level == '\u0000')
            {
                response.AddError("002", $"Field {fieldname} can't be null or zero");
            }
            else if (!this._teacherRepository.ExistByLevelId(level.Value))
            {
                //Tentar passar os valores possíveis sem escrever na mão
                response.AddError("005", $"Invalid {fieldname}! Choose {this._teacherRepository.ValidLevelIds().ToString()} J or P or S");
            }
        }

        public void ValidateSalary(decimal? salary, OperationResponseBase response, string fieldname)
        {
            if(salary == null || salary == decimal.MinValue)
            {
                response.AddError("002", $"Field {fieldname} can't be null or zero");
            }
            else if(salary > ModelConstants.Teacher.MaxSalary || salary < ModelConstants.Teacher.MinSalary)
            {
                response.AddError("007", $"Value of {fieldname} don't accepted! Choose a value between {ModelConstants.Teacher.MinSalary} and {ModelConstants.Teacher.MaxSalary}");
            }
        }

        public void ValidateAdmitionDate(DateTime? admitionDate, OperationResponseBase response, string fieldname)
        {
            if(admitionDate == null || admitionDate == DateTime.MinValue)
            {
                response.AddError("002", $"Field {fieldname} can't be null or zero");
            }
            else if (admitionDate > DateTime.MinValue && admitionDate > DateTime.Today)
            {
                response.AddError("008", $"{fieldname} can't be bigger than today");
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

        public bool ValidateLevel(char? level)
        {
            if (level != null && level != '\u0000' && level != 'J' && level != 'P' && level != 'S')
            {
                return false;
            }

            return true;
        }

        public void ValidatePageSize(int pageSize, OperationResponseBase response)
        {
            if(pageSize <= 0)
            {
                response.AddError("002", $"Field {pageSize} can't be null or zero");
            }
            else if (pageSize > ModelConstants.Teacher.MaxTeachersPerPage)
            {
                response.Errors.Add(new OperationError("015", "Number of teachers exceeded the limit"));
            }
        }

        public void ValidatePageNumber(int pageNumber, OperationResponseBase response)
        {
            if (pageNumber <= 0)
            {
                response.AddError("002", $"Field {pageNumber} can't be null or zero");
            }
        }
    }
}
