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

            this.ValidateFormat(request, response);

            if (response.Errors.Count > 0)
            {
                return response;
            }

            this.ValidateBusinessRules(request, response);

            if (response.Errors.Count == 0)
            {
                response.Success = true;
            }

            return response;
        }

        private void ValidateFormat(InsertTeacherRequest request, InsertTeacherResponse response)
        {
            if (request.Data.CPF == 0)
            {
                response.Errors.Add(new OperationError("002", "CPF can't be null"));
            }

            if (request.Data.Name == null)
            {
                response.Errors.Add(new OperationError("009", "Name can't be null"));
            }
            else
            {
                if (request.Data.Name.Length > 32)
                {
                    response.Errors.Add(new OperationError("004", "Name lenght don't supported! Limit: 32 caracters"));
                }
            }

            if (request.Data.Gender == '\u0000')
            {
                response.Errors.Add(new OperationError("010", "Gender can't be null"));
            }
            else
            {
                if (request.Data.Gender != 'F' && request.Data.Gender != 'M')
                {
                    response.Errors.Add(new OperationError("005", "Invalid Gender! Choose M or F"));
                }
            }

            if (request.Data.Level == '\u0000')
            {
                response.Errors.Add(new OperationError("011", "Level can't be null"));
            }
            else
            {
                if (request.Data.Level != 'J' && request.Data.Level != 'P' && request.Data.Level != 'S')
                {
                    response.Errors.Add(new OperationError("006", "Invalid Level! Choose J or P or S"));
                }
            }

            if (request.Data.Salary == decimal.Zero)
            {
                response.Errors.Add(new OperationError("012", "Salary can't be null"));
            }
            else
            {
                if (request.Data.Salary < 1000 || request.Data.Salary > 10000)
                {
                    response.Errors.Add(new OperationError("007", "Value don't accepted! Choose some value betewwn 1000 and 10000"));
                }
            }

            if (request.Data.AdmitionDate == DateTime.MinValue)
            {
                response.Errors.Add(new OperationError("013", "AdmitionDate can't be null"));
            }
            else
            {
                if (request.Data.AdmitionDate > DateTime.Today)
                {
                    response.Errors.Add(new OperationError("008", "Admition date can't be bigger than today"));
                }
            }
        }
        private void ValidateBusinessRules(InsertTeacherRequest request, InsertTeacherResponse response)
        {

        } 
    }
}
