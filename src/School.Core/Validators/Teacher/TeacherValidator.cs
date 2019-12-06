using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using School.Core.ValidatorsTeacher;
using School.Core.Validators.ValidateTeacherParameters;

namespace School.Core.ValidatorsTeacher
{
    public class TeacherValidator : ITeacherValidator
    {
        private readonly ITeacherParametersValidator _validator;

        public TeacherValidator(ITeacherParametersValidator validator)
        {
            this._validator = validator;
        }

        public bool ValidateTeacher(Teacher teacher, OperationResponseBase response)
        {

            if (teacher == null)
            {
                response.Errors.Add(new OperationError("001", "Request can't be null"));
                return false;
            }

            this._validator.ValidateNullOrZero(teacher.TeacherId, response, nameof(teacher.TeacherId));

            if (response.Errors.Count > 0)
            {
                return false;
            }

            //Validate if parameters are null
            this._validator.ValidateNullOrZero(teacher.Name, response, nameof(teacher.Name));
            this._validator.ValidateNullOrZero(teacher.Gender, response, nameof(teacher.Gender));
            this._validator.ValidateNullOrZero(teacher.LevelId, response, nameof(teacher.LevelId));
            this._validator.ValidateNullOrZero(teacher.Salary, response, nameof(teacher.Salary));
            this._validator.ValidateNullOrZero(teacher.AdmitionDate, response, nameof(teacher.AdmitionDate));

            if (response.Errors.Count > 0)
            {
                return false;
            }

            //Put gender and level in upper case if they aren't
            teacher.Gender = this._validator.ValidateUpperCase(teacher.Gender);
            teacher.LevelId = this._validator.ValidateUpperCase(teacher.LevelId);
            //Validate format
            this._validator.ValidateMaxLength(teacher.Name, ModelConstants.Teacher.NameMaxLength, response);
            this._validator.ValidateGender(teacher.Gender, response);
            this._validator.ValidateLevel(teacher.LevelId, response);
            this._validator.ValidateMinMaxSalary(teacher.Salary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response);
            this._validator.ValidateAdmitionDate(teacher.AdmitionDate, response);

            if (response.Errors.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}