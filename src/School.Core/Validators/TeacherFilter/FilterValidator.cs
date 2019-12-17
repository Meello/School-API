using School.Core.Models;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;

namespace School.Core.Validators.TeacherFilter
{
    public class FilterValidator : IFilterValidator
    {
        private readonly ITeacherParametersValidator _parameterValidator;

        public FilterValidator(ITeacherParametersValidator parameterValidator)
        {
            this._parameterValidator = parameterValidator;
        }

        public SearchTeacherResponse ValidateParameters(RequestFilter requestFilter)
        {
            SearchTeacherResponse response = new SearchTeacherResponse();

            if(requestFilter == null)
            {
                return response;
            }

            int count = 0;

            if (requestFilter.Genders != null)
            {
                foreach (char? gender in requestFilter.Genders)
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
                response.Errors.Add(new OperationError("017", $"{count} values in {nameof(requestFilter.Genders)} list invalid "));
                count = 0;
            }

            if(requestFilter.LevelIds != null)
            {
                foreach (char? level in requestFilter.LevelIds)
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
                response.Errors.Add(new OperationError("017", $"{count} values in {nameof(requestFilter.LevelIds)} list invalid "));
            }

            this._parameterValidator.ValidateAdmitionDate(requestFilter.MinAdmitionDate, response, nameof(requestFilter.MinAdmitionDate));
            this._parameterValidator.ValidateAdmitionDate(requestFilter.MaxAdmitionDate, response, nameof(requestFilter.MaxAdmitionDate));
            this._parameterValidator.ValidateMinMaxSalary(requestFilter.MaxSalary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response, nameof(requestFilter.MaxSalary));
            this._parameterValidator.ValidateMinMaxSalary(requestFilter.MinSalary, ModelConstants.Teacher.MinSalary, ModelConstants.Teacher.MaxSalary, response, nameof(requestFilter.MinSalary));
            

            if(requestFilter.MaxSalary < requestFilter.MinSalary)
            {
                response.Errors.Add(new OperationError("019",$"{nameof(requestFilter.MaxSalary)} can't be bigger than {nameof(requestFilter.MinSalary)}"));
            }

            if (requestFilter.MaxAdmitionDate < requestFilter.MinAdmitionDate)
            {
                response.Errors.Add(new OperationError("019", $"{nameof(requestFilter.MaxAdmitionDate)} can't be bigger than {nameof(requestFilter.MinAdmitionDate)}"));
            }

            return response;
        }
    }
}
