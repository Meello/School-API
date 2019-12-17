using School.Core.Filters;
using School.Core.Mapping;
using School.Core.Models;
using System.Linq;
using School.Core.Repositories;
using School.Core.Validators.TeacherFilter;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System.Collections.Generic;
using School.Core.Validators.ValidateTeacherParameters;

namespace School.Core.Operations.SearchTeacher
{
    public class SearchTeacher : OperationBase<SearchTeacherRequest, SearchTeacherResponse>, ISearchTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IFilterValidator _filterValidator;
        private readonly ITeacherParametersValidator _parameterValidator;

        public SearchTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IFilterValidator filterValidator, ITeacherParametersValidator parameterValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._filterValidator = filterValidator;
            this._parameterValidator = parameterValidator;
        }

        protected override SearchTeacherResponse ProcessOperation(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = new SearchTeacherResponse();

            TeacherFilter teacherFilter = this._mappingResolver.BuildFrom(request.Data);

            PagedResult<Teacher> teachers = this._teacherRepository.ListPagedByFilter(teacherFilter, request.PageNumber, request.PageSize);

            response.Data = this._mappingResolver.BuildFrom(teachers.Results);

            return response;
        }

        protected override SearchTeacherResponse ValidateOperation(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = new SearchTeacherResponse();

            this._parameterValidator.ValidatePage(request.PageNumber, request.PageSize, response);

            if(!response.Success)
            {
                return response;
            }

            response = this._filterValidator.ValidateParameters(request.Data);

            return response;
        }
    }
}
