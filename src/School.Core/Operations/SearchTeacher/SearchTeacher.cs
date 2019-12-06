using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators;
using School.Core.Validators.DataBaseValidator;
using StoneCo.Buy4.School.DataContracts.FilterTeacher;

namespace School.Core.Operations.FilterTeacher
{
    public class SearchTeacher : ISearchTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IInsertTeacherValidator _validator;
        private readonly IDataBaseValidator _dataBaseValidator;

        public SearchTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IInsertTeacherValidator validator, IDataBaseValidator dataBaseValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
            this._dataBaseValidator = dataBaseValidator;
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
