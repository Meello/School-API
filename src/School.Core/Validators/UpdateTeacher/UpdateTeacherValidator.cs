using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using School.Core.Repositories;
using System.Text;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;

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
            
            validator.ValidateMaxLength(request.Data.Name, response);
            validator.ValidateGender(request.Data.Gender, response);
            validator.ValidateLevel(request.Data.Level, response);
            validator.ValidateSalary(request.Data.Salary, response);
            validator.ValidateAdmitionDate(request.Data.AdmitionDate, response);

            if (response.Errors.Count == 0)
            {
                response.Success = true;
            }

            return response;
        }
    }
}
