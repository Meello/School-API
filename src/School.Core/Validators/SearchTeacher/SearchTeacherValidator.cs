using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Models;
using School.Core.Validators.DataBaseValidator;
using School.Core.Validators.Page;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;

namespace School.Core.Validators.SearchTeacher
{
    public class SearchTeacherValidator : ISearchTeacherValidator
    {
        private readonly ITeacherParametersValidator _parameterValidator;
        private readonly IPageValidator _pageValidator;

        public SearchTeacherValidator(ITeacherParametersValidator parameterValidator, IPageValidator pageValidator)
        {
            this._parameterValidator = parameterValidator;
            this._pageValidator = pageValidator;
        }

        public SearchTeacherResponse ValidateParameters(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = new SearchTeacherResponse
            {
                Notifications = new List<OperationNotification>(),
                Errors = new List<OperationError>()
            };

            int count = 0;

            if (request.Data.Gender != null)
            {
                //quando a lista é nula, foreach não funciona
                foreach (char? gender in request.Data.Gender)
                {
                    if (this._parameterValidator.ValidateUpperCase(gender) == true)
                    {
                        if (this._parameterValidator.ValidateGender(gender) == false)
                        {
                            count += 1;
                        }
                    }
                    else
                    {
                        count += 1;
                    }
                }
            }

            if (count > 0)
            {
                response.Errors.Add(new OperationError("017", $"{count} values in {nameof(request.Data.Gender)} list invalid "));
                count = 0;
            }

            if(request.Data.LevelId != null)
            {
                foreach (char? level in request.Data.LevelId)
                {
                    if (this._parameterValidator.ValidateUpperCase(level) == true)
                    {
                        if (this._parameterValidator.ValidateLevel(level) == false)
                        {
                            count += 1;
                        }
                    }
                    else
                    {
                        count += 1;
                    }
                }
            }
                        
            if (count > 0)
            {
                response.Errors.Add(new OperationError("017", $"{count} values in {nameof(request.Data.LevelId)} list invalid "));
            }

            this._parameterValidator.ValidateAdmitionDate(request.Data.MinAdmitionDate, response, nameof(request.Data.MinAdmitionDate));
            this._parameterValidator.ValidateAdmitionDate(request.Data.MaxAdmitionDate, response, nameof(request.Data.MaxAdmitionDate));
            this._parameterValidator.ValidateMinMaxSalary(request.Data.MaxSalary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response, nameof(request.Data.MaxSalary));
            this._parameterValidator.ValidateMinMaxSalary(request.Data.MinSalary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response, nameof(request.Data.MinSalary));
            this._parameterValidator.ValidateNullOrZero(request.PageSize, response, nameof(request.PageSize));
            this._parameterValidator.ValidateNullOrZero(request.PageNumber, response, nameof(request.PageNumber));

            if (response.Errors.Count == 0)
            {
                response.Success = true;
            }

            //string.Join(",", request.Data.Gender.ToArray()); => passar lista inteira para string para poder printar

            return response;
        }
        
        public void ValidatePage(long maxElements, long? pageSize, long? pageNumber, SearchTeacherResponse response)
        {
            this._pageValidator.ValidatePage(pageSize.Value, (pageNumber.Value - 1) * pageSize.Value, maxElements, response);
        }
    }
}
