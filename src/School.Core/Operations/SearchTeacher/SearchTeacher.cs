using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators;
using School.Core.Validators.IdValidator;
using StoneCo.Buy4.School.DataContracts.FilterTeacher;

namespace School.Core.Operations.FilterTeacher
{
    public class SearchTeacher : ISearchTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IInsertTeacherValidator _validator;
        private readonly IDataBaseValidator _idExistValidator;

        public SearchTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IInsertTeacherValidator validator, IDataBaseValidator idExistValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
            this._idExistValidator = idExistValidator;
        }

        public SearchTeacherResponse ProcessOperation(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = new SearchTeacherResponse();
            //SearchTeacherResponse response = this._validator.ValidateOperation(request);

            IEnumerable<Teacher> teachers = this._teacherRepository.Search(request.Data);

            response.Data = this._mappingResolver.BuildFrom(teachers);

            response.Success = true;

            return response;
        }
    }
}
