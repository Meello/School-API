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

            //Validate format
            this._validator.ValidateMaxLength(requestData.Name, ModelConstants.Teacher.NameMaxLength, response, nameof(requestData.Name));
            this._validator.ValidateMinMaxSalary(requestData.Salary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response, nameof(requestData.Salary));
            this._validator.ValidateAdmitionDate(requestData.AdmitionDate, response, nameof(requestData.AdmitionDate));
            
            if(this._validator.ValidateUpperCase(requestData.Gender, response, nameof(requestData.Gender)) == true)
            {
                this._validator.ValidateGender(requestData.Gender, response, nameof(requestData.Gender));
            }
            
            if(this._validator.ValidateUpperCase(requestData.Level, response, nameof(requestData.Level)) == true)
            {
                this._validator.ValidateLevel(requestData.Level, response, nameof(requestData.Level));
            }
            
            if (response.Errors.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}