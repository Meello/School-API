using Dapper;
using School.Core.Models;
using School.Core.Validators.DataBaseValidator;
using School.Core.Validators.Page;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.GetTeacherPerPage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace School.Core.Validators.GetTeachersPerPage
{
    public class GetTeachersPerPageValidator : IGetTeachersPerPageValidator
    {
        private readonly IDataBaseValidator _validator;
        private readonly IPageValidator _pageValidator;
        private readonly ITeacherParametersValidator _parametersValidator;

        public GetTeachersPerPageValidator(IDataBaseValidator validator, IPageValidator pageValidator, ITeacherParametersValidator parametersValidator)
        {
            this._validator = validator;
            this._pageValidator = pageValidator;
            this._parametersValidator = parametersValidator;
        }
        
        public GetTeachersPerPageResponse ValidateOperation(long pageNumber, long pageSize)
        {
            GetTeachersPerPageResponse response = new GetTeachersPerPageResponse
            {
                Errors = new List<OperationError>(),
                Notifications = new List<OperationNotification>()
            };

            this._parametersValidator.ValidateNullOrZero(pageNumber, response, nameof(pageNumber));
            this._parametersValidator.ValidateNullOrZero(pageSize, response, nameof(pageSize));

            if(response.Errors.Count > 0)
            {
                return response;
            }

            long maxElements = this._validator.NumberOfElements();

            this._pageValidator.ValidatePage(pageSize, pageNumber, maxElements, response);
            
            return response;
        }
    }
}
