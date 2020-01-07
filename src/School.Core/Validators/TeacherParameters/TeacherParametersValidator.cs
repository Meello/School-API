using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using School.Core.Repositories;
using System.Linq;
using School.Core.Validators.NullOrZero;

namespace School.Core.Validators.ValidateTeacherParameters
{
    public class TeacherParametersValidator : ITeacherParametersValidator
    {
        private readonly ILevelRepository _levelRepository;

        public TeacherParametersValidator(
            ILevelRepository levelRepository)
        {
            this._levelRepository = levelRepository;
        }

        public void ValidateTeacherId(long? value, OperationResponseBase response)
        {
            if (value == null || value == 0)
            {
                response.AddError("002", $"TeacherId can't be null or zero.");
            }
        }

        public void ValidateName(string name, OperationResponseBase response)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                response.AddError("002", $"Name can't be null or empty.");

                return;
            }
            
            if (name.Length > ModelConstants.Teacher.NameMaxLength)
            {
                response.AddError("004", $"Invalid name length: {name.Length} exceeded the limit! Max: {ModelConstants.Teacher.NameMaxLength}.");
            }

            if (Regex.IsMatch(name, @"[^a-zA-Z]"))
            {
                response.AddError("020",$"Name can't have specials characters.");
            }
        }

        public void ValidateGender(char? gender, OperationResponseBase response)
        {
            if(!this.IsGenderValid(gender))
            {
                response.AddError("005", $"Invalid gender value: {gender}! Gender must be 'M' or 'F'");
            }
        }

        public void ValidateLevel(char? level, OperationResponseBase response)
        {
            IEnumerable<char> levels = this._levelRepository.ListAll();

            if (!levels.Any(l => l == level))
            {
                response.AddError("005", $"Invalid level value: {level}! Valid levels: {string.Join(", ",levels.ToArray())}");
            }
        }

        public void ValidateSalary(decimal? salary, OperationResponseBase response, string filedname)
        {
            if(salary > ModelConstants.Teacher.MaxSalary || salary < ModelConstants.Teacher.MinSalary)
            {
                response.AddError("007", $"{filedname} value: {salary} don't accepted! Choose a value between {ModelConstants.Teacher.MinSalary} and {ModelConstants.Teacher.MaxSalary}");
            }
        }

        public void ValidateAdmitionDate(DateTime? admitionDate, OperationResponseBase response, string fieldname)
        {
            if(admitionDate == DateTime.MinValue || admitionDate == null)
            {
                response.AddError("002",$"{fieldname} value: {admitionDate} can't be null or zero");
            }
            else if (admitionDate > DateTime.MinValue && admitionDate > DateTime.Today)
            {
                response.AddError("008", $"{fieldname} value: {admitionDate} can't be bigger than today");
            }
        }

        public bool IsGenderValid(char? gender)
        {
            if (gender == 'F' || gender == 'M')
            {
                return true;
            }

            return false;
        }

        public void ValidatePageSize(int? pageSize, OperationResponseBase response)
        {
            if(pageSize <= 0 || pageSize == null)
            {
                response.AddError("002", $"Page size: {pageSize} can't be null or zero.");
            }
            else if (pageSize > ModelConstants.Teacher.MaxTeachersPerPage)
            {
                response.Errors.Add(new OperationError("015", $"Page size value: {pageSize} exceeded the limit."));
            }
        }

        public void ValidatePageNumber(int? pageNumber, OperationResponseBase response)
        {
            if (pageNumber <= 0 || pageNumber == null)
            {
                response.AddError("002", $"Page number: {pageNumber} can't be null or zero.");
            }
        }
    }
}
