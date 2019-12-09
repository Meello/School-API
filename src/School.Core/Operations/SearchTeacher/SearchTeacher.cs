using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators;
using School.Core.Validators.DataBaseValidator;
using School.Core.Validators.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;

namespace School.Core.Operations.SearchTeacher
{
    public class SearchTeacher : ISearchTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly ISearchTeacherValidator _validator;
        private readonly IDataBaseValidator _dataBaseValidator;

        public SearchTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, ISearchTeacherValidator validator, IDataBaseValidator dataBaseValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
            this._dataBaseValidator = dataBaseValidator;
        }

        public SearchTeacherResponse ProcessOperation(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = this._validator.ValidateParameters(request.Data);

            List<Teacher> teachers = this._teacherRepository.Search(request.Data).ToList();

            this._validator.ValidatePage(teachers.Count, request.Data.PageSize.Value, request.Data.PageNumber.Value, response);
            
            

            response.Data = this._mappingResolver.BuildFrom(teachers);

            response.Success = true;

            return response;
        }
    }
}
