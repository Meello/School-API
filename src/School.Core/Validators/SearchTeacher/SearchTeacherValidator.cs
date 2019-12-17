using School.Core.Models;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;

namespace School.Core.Validators.SearchTeacher
{
    public class SearchTeacherValidator : ISearchTeacherValidator
    {
        private readonly ITeacherParametersValidator _parameterValidator;

        public SearchTeacherValidator(ITeacherParametersValidator parameterValidator)
        {
            this._parameterValidator = parameterValidator;
        }

        public SearchTeacherResponse ValidateParameters(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = new SearchTeacherResponse();

            int count = 0;

            if (request.Data.Genders != null)
            {
                foreach (char? gender in request.Data.Genders)
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
                response.Errors.Add(new OperationError("017", $"{count} values in {nameof(request.Data.Genders)} list invalid "));
                count = 0;
            }

            if(request.Data.LevelIds != null)
            {
                foreach (char? level in request.Data.LevelIds)
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
                response.Errors.Add(new OperationError("017", $"{count} values in {nameof(request.Data.LevelIds)} list invalid "));
            }

            this._parameterValidator.ValidateAdmitionDate(request.Data.MinAdmitionDate, response, nameof(request.Data.MinAdmitionDate));
            this._parameterValidator.ValidateAdmitionDate(request.Data.MaxAdmitionDate, response, nameof(request.Data.MaxAdmitionDate));
            this._parameterValidator.ValidateMinMaxSalary(request.Data.MaxSalary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response, nameof(request.Data.MaxSalary));
            this._parameterValidator.ValidateMinMaxSalary(request.Data.MinSalary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response, nameof(request.Data.MinSalary));
            this._parameterValidator.ValidateNullOrZero(request.PageSize, response, nameof(request.PageSize));
            this._parameterValidator.ValidateNullOrZero(request.PageNumber, response, nameof(request.PageNumber));

            if(request.Data.MaxSalary < request.Data.MinSalary)
            {
                response.Errors.Add(new OperationError("019",$"{nameof(request.Data.MaxSalary)} can't be bigger than {nameof(request.Data.MinSalary)}"));
            }

            if (request.Data.MaxAdmitionDate < request.Data.MinAdmitionDate)
            {
                response.Errors.Add(new OperationError("019", $"{nameof(request.Data.MaxAdmitionDate)} can't be bigger than {nameof(request.Data.MinAdmitionDate)}"));
            }

            this._parameterValidator.ValidatePage(request.PageSize, response);

            return response;
        }
    }
}
