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

            if (requestData == null)
            {
                response.Errors.Add(new OperationError("001", "Request can't be null"));
                return false;
            }

            this._validator.ValidateNullOrZero(requestData.CPF, response, nameof(requestData.CPF));

            if (response.Errors.Count > 0)
            {
                return false;
            }

            //Validate if parameters are null
            this._validator.ValidateNullOrZero(requestData.Name, response, nameof(requestData.Name));
            this._validator.ValidateNullOrZero(requestData.Gender, response, nameof(requestData.Gender));
            this._validator.ValidateNullOrZero(requestData.Level, response, nameof(requestData.Level));
            this._validator.ValidateNullOrZero(requestData.Salary, response, nameof(requestData.Salary));
            this._validator.ValidateNullOrZero(requestData.AdmitionDate, response, nameof(requestData.AdmitionDate));

            if (response.Errors.Count > 0)
            {
                return false;
            }

            //Put gender and level in upper case if they aren't
            requestData.Gender = this._validator.ValidateUpperCase(requestData.Gender);
            requestData.Level = this._validator.ValidateUpperCase(requestData.Level);
            //Validate format
            this._validator.ValidateMaxLength(requestData.Name, ModelConstants.Teacher.NameMaxLength, response);
            this._validator.ValidateGender(requestData.Gender, response);
            this._validator.ValidateLevel(requestData.Level, response);
            this._validator.ValidateMinMaxSalary(requestData.Salary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response);
            this._validator.ValidateAdmitionDate(requestData.AdmitionDate, response);

            if (response.Errors.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}