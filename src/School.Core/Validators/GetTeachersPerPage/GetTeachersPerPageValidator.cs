using Dapper;
using School.Core.Models;
using School.Core.Validators.DataBaseValidator;
using School.Core.Validators.Page;
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

        public GetTeachersPerPageValidator(IDataBaseValidator validator, IPageValidator pageValidator)
        {
            this._validator = validator;
            this._pageValidator = pageValidator;
        }
        
        public GetTeachersPerPageResponse ValidateOperation(long pageNumber, long elementsPerPage)
        {
            GetTeachersPerPageResponse response = new GetTeachersPerPageResponse
            {
                Errors = new List<OperationError>(),
                Notifications = new List<OperationNotification>()
            };

            long maxElements = this._validator.NumberOfElements();

            long offset = elementsPerPage * (pageNumber - 1);

            this._pageValidator.ValidatePage(elementsPerPage, offset, maxElements, response);
            
            /*
            if (elementsPerPage > ModelConstants.Teacher.MaxTeachersPerPage)
            {
                response.Errors.Add(new OperationError("015", "Number of teachers exceeded the limit"));
            }

            if (offset >= maxElements)
            {
                response.Errors.Add(new OperationError("016", "Values can't be find! Incorrect search local"));
            }

            if (response.Errors.Count == 0)
            {
                if (elementsPerPage > maxElements - offset)
                {
                    response.Notifications.Add(new OperationNotification(
                        "001",
                        "The number of elements requested can't be found. " +
                        $"Number of elements found: {maxElements - offset}. " +
                        $"Number of elements requested: {elementsPerPage}"));
                }
                
                response.Success = true;
            }
            */
            return response;
        }
    }
}
