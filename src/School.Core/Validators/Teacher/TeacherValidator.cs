using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using School.Core.ValidatorsTeacher;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;

namespace School.Core.ValidatorsTeacher
{
    public class TeacherValidator : ITeacherValidator
    {
        private readonly ITeacherParametersValidator _validator;

        public TeacherValidator(ITeacherParametersValidator validator)
        {
            this._validator = validator;
        }

        public void ValidateTeacher(Teacher teacher, OperationResponseBase response)
        {
            if(teacher == null)
            {
                response.AddError("001", "Request can't be null");
            }
            else
            {
                this._validator.ValidateTeacherId(teacher.TeacherId, response, nameof(teacher.TeacherId));
                this._validator.ValidateName(teacher.Name, response, nameof(teacher.Name));
                this._validator.ValidateGender(teacher.Gender, response, nameof(teacher.Gender));
                this._validator.ValidateLevel(teacher.Level, response, nameof(teacher.Level));
                this._validator.ValidateSalary(teacher.Salary, response, nameof(teacher.Salary));
                this._validator.ValidateAdmitionDate(teacher.AdmitionDate, response, nameof(teacher.AdmitionDate));
            }
        }
    }
}