using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using School.Core.Repositories;
using System.Text;

namespace School.Core.Validators.UpdateTeacher
{
    public class UpdateTeacherValidator : IUpdateTeacherValidator
    {
        public UpdateTeacherResponse ValidateFormat(UpdateTeacherRequest request, UpdateTeacherResponse response)
        {
            if (request.Data.CPF == 0)
            {
                response.Errors.Add(new OperationError("002", "CPF can't be null"));
            }

            if(request.Data.Name != null)
            {
                if (request.Data.Name.Length > 32)
                {
                    response.Errors.Add(new OperationError("004", "Name lenght don't supported! Limit: 32 caracters"));
                }
            }

            if (request.Data.Gender != null)
            {
                if (request.Data.Gender != 'F' && request.Data.Gender != 'M')
                {
                    response.Errors.Add(new OperationError("005", "Invalid Gender! Choose M or F"));
                }
            }

            if (request.Data.Level != null)
            {
                if (request.Data.Level != 'J' && request.Data.Level != 'P' && request.Data.Level != 'S')
                {
                    response.Errors.Add(new OperationError("006", "Invalid Level! Choose J or P or S"));
                }
            }

            if (request.Data.Salary != null)
            {
                if (request.Data.Salary < 1000 || request.Data.Salary > 10000)
                {
                    response.Errors.Add(new OperationError("007", "Value don't accepted! Choose some value betewwn 1000 and 10000"));
                }
            }

            if (request.Data.AdmitionDate != null)
            {
                if (request.Data.AdmitionDate > DateTime.Today)
                {
                    response.Errors.Add(new OperationError("008", "Admition date can't be bigger than today"));
                }
            }

            if (response.Errors.Count == 0)
            {
                response.Success = true;
            }

            return response;
        }

        public UpdateTeacherResponse ValidateBusinessRules(UpdateTeacherRequest request, UpdateTeacherResponse response)
        {
            if (request.Data == null)
            {
                response.Errors.Add(new OperationError("003", "CPF not found"));
            }

            return response;
        }
    }
}
