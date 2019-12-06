using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.Page
{
    public class PageValidator : IPageValidator
    {
        public void ValidatePage(long elementsPerPage, long offset, long maxElements, OperationResponseBase response)
        {
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
        }
    }
}
