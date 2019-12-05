using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using School.Core.Repositories;
using System.Text;
using School.Core.Validators.ValidateTeacherParameters;
using School.Core.Models;

namespace School.Core.Validators.UpdateTeacher
{
    public class UpdateTeacherValidator : IUpdateTeacherValidator
    {
        public UpdateTeacherResponse ValidateProcess(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = new UpdateTeacherResponse
            {
                Errors = new List<OperationError>()
            };

            if (request.Data == null)
            {
                response.Errors.Add(new OperationError("001", "Request can't be null"));
                return response;
            }

            TeacherParametersValidator validator = new TeacherParametersValidator();

            validator.ValidateNullOrZero(request.Data.CPF, response, nameof(UpdateTeacherRequest.Data.CPF));

            if (response.Errors.Count > 0)
            {
                return response;
            }
            
            //Validate if parameters are null
            validator.ValidateNullOrZero(request.Data.Name, response, nameof(UpdateTeacherRequest.Data.Name));
            validator.ValidateNullOrZero(request.Data.Gender, response, nameof(UpdateTeacherRequest.Data.Gender));
            validator.ValidateNullOrZero(request.Data.Level, response, nameof(UpdateTeacherRequest.Data.Level));
            validator.ValidateNullOrZero(request.Data.Salary, response, nameof(UpdateTeacherRequest.Data.Salary));
            validator.ValidateNullOrZero(request.Data.AdmitionDate, response, nameof(UpdateTeacherRequest.Data.AdmitionDate));

            if (response.Errors.Count > 0)
            {
                return response;
            }

            //Put gender and level in upper case if they aren't
            request.Data.Gender = validator.ValidateUpperCase(request.Data.Gender);
            request.Data.Level = validator.ValidateUpperCase(request.Data.Level);
            //Validate format
            validator.ValidateMaxLength(request.Data.Name, ModelConstants.Teacher.NameMaxLength, response);
            validator.ValidateGender(request.Data.Gender, response);
            validator.ValidateLevel(request.Data.Level, response);
            validator.ValidateMinMaxSalary(request.Data.Salary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response);
            validator.ValidateAdmitionDate(request.Data.AdmitionDate, response);
            
            if (response.Errors.Count == 0)
            {
                response.Success = true;
            }

            return response;
        }
    }
}
