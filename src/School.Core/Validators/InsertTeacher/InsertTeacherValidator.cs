using School.Core.Models;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators
{
    public class InsertTeacherValidator : IInsertTeacherValidator
    {
        public InsertTeacherResponse ValidateOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = new InsertTeacherResponse
            {
                Errors = new List<OperationError>()
            };

            if (request.Data == null)
            {
                response.Errors.Add(new OperationError("001", "Request can't be null"));
                return response;
            }

            TeacherParametersValidator validator = new TeacherParametersValidator();
            //Validate if parameters are null
            validator.ValidateNullOrZero(request.Data.CPF, response, nameof(InsertTeacherRequest.Data.CPF));
            validator.ValidateNullOrZero(request.Data.Name, response, "Name");
            validator.ValidateNullOrZero(request.Data.Gender, response, "Gender");
            validator.ValidateNullOrZero(request.Data.Level, response, "Level");
            validator.ValidateNullOrZero(request.Data.Salary, response, "Salary");
            validator.ValidateNullOrZero(request.Data.AdmitionDate, response, "AdmitionDate");
            //Validate format
            validator.ValidateMaxLength(request.Data.Name, ModelConstants.Teacher.NameMaxLength, response);
            validator.ValidateGender(request.Data.Gender, response);
            validator.ValidateLevel(request.Data.Level, response);
            validator.ValidateSalary(request.Data.Salary, response);
            validator.ValidateAdmitionDate(request.Data.AdmitionDate, response);

            if (response.Errors.Count > 0)
            {
                return response;
            }

            response.Success = true;
            return response;

            //falta validar se o cpf já existe
        }
    }
}
