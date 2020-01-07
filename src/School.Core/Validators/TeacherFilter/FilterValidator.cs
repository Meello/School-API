using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators.TeacherFilterParameters;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System.Collections.Generic;
using System.Linq;

namespace School.Core.Validators.TeacherFilter
{
    public class FilterValidator : IFilterValidator
    {
        private readonly ILevelRepository _levelRepository;
        private readonly ITeacherFilterParametersValidator _parameterValidator;

        public FilterValidator(
            ILevelRepository levelRepository,
            ITeacherFilterParametersValidator parameterValidator)
        {
            this._levelRepository = levelRepository;
            this._parameterValidator = parameterValidator;
        }

        public SearchTeacherResponse ValidateParameters(RequestFilter requestFilter)
        {
            SearchTeacherResponse response = new SearchTeacherResponse();

            if(requestFilter == null)
            {
                return response;
            }

            this._parameterValidator.ValidateGenders(requestFilter.Genders, response);

            this._parameterValidator.ValidateLevelIds(requestFilter.LevelIds, response);

            this._parameterValidator.ValidateAdmitionDate(requestFilter.MinAdmitionDate, requestFilter.MaxAdmitionDate, response);

            this._parameterValidator.ValidateSalary(requestFilter.MinSalary, requestFilter.MaxSalary, response);
            
            return response;
        }
    }
}
