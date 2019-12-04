using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using School.Core.Repositories;
using System.Text;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
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

            validator.ValidateNullOrZero(request.Data.CPF, response, "CPF");
            
            if(response.Errors.Count > 0)
            {
                return response;
            }

            //Validate if parameters are null
            validator.ValidateNullOrZero(request.Data.Name, response, "Name");
            validator.ValidateNullOrZero(request.Data.Gender, response, "Gender");
            validator.ValidateNullOrZero(request.Data.Level, response, "Level");
            validator.ValidateNullOrZero(request.Data.Salary, response, "Salary");
            validator.ValidateNullOrZero(request.Data.AdmitionDate, response, "AdmitionDate");
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
