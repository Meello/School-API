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

        public bool ValidateTeacher(TeacherRequestData requestData, OperationResponseBase response)
        {
            this._validator.ValidateTeacherId(requestData.TeacherId, response, nameof(requestData.TeacherId));
            this._validator.ValidateName(requestData.Name, response, nameof(requestData.Name));
            this._validator.ValidateGender(requestData.Gender, response, nameof(requestData.Gender));
            this._validator.ValidateLevel(requestData.Level, response, nameof(requestData.Level));
            this._validator.ValidateSalary(requestData.Salary, response, nameof(requestData.Salary));
            this._validator.ValidateAdmitionDate(requestData.AdmitionDate, response, nameof(requestData.AdmitionDate));

            if (response.Errors.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}