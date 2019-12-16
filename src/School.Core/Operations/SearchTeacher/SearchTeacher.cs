using School.Core.Mapping;
using School.Core.Repositories;
using School.Core.Validators.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;

namespace School.Core.Operations.SearchTeacher
{
    public class SearchTeacher : OperationBase<SearchTeacherRequest, SearchTeacherResponse>, ISearchTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly ISearchTeacherValidator _validator;

        public SearchTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, ISearchTeacherValidator validator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
        }

        protected override SearchTeacherResponse ProcessOperation(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = new SearchTeacherResponse();



            //IEnumerable<Teacher> teachers = this._teacherRepository.ListPagedByFilter();

            //response.Data = this._mappingResolver.BuildFrom(teachers);

            return response;
        }

        protected override SearchTeacherResponse ValidateOperation(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = this._validator.ValidateParameters(request);
            
            return response;
        }
    }
}
