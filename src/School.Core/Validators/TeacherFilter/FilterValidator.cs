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
                    if (this._parameterValidator.ValidateGender(gender) == true)
                    {
                        count += 1;
                    }
                }
            }

            if (count > 0)
            {
                response.AddError("017", $"{count} values in {nameof(requestFilter.Genders)} list invalid ");
                count = 0;
            }

            if(requestFilter.LevelIds != null)
            {
                foreach (char? level in requestFilter.LevelIds)
                {
                    if (this._parameterValidator.ValidateLevel(level) == false)
                    {
                        count += 1;
                    }
                }
            }
                        
            if (count > 0)
            {
                response.AddError("017", $"{count} values in {nameof(requestFilter.LevelIds)} list invalid ");
            }

            this._parameterValidator.ValidateAdmitionDate(requestFilter.MinAdmitionDate, response, nameof(requestFilter.MinAdmitionDate));
            this._parameterValidator.ValidateAdmitionDate(requestFilter.MaxAdmitionDate, response, nameof(requestFilter.MaxAdmitionDate));
            this._parameterValidator.ValidateSalary(requestFilter.MaxSalary, response, nameof(requestFilter.MaxSalary));
            this._parameterValidator.ValidateSalary(requestFilter.MinSalary, response, nameof(requestFilter.MinSalary));
            

            if(requestFilter.MaxSalary < requestFilter.MinSalary)
            {
                response.AddError("019",$"{nameof(requestFilter.MaxSalary)} can't be bigger than {nameof(requestFilter.MinSalary)}");
            }

            if (requestFilter.MaxAdmitionDate < requestFilter.MinAdmitionDate)
            {
                response.AddError("019", $"{nameof(requestFilter.MaxAdmitionDate)} can't be bigger than {nameof(requestFilter.MinAdmitionDate)}");
            }

            return response;
        }
    }
}
