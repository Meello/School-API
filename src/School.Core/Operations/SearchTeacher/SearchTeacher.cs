using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
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
        private readonly IIdExistValidator _idExistValidator;

        public SearchTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IInsertTeacherValidator validator, IIdExistValidator idExistValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
            this._idExistValidator = idExistValidator;
        }

        public SearchTeacherResponse ProcessOperation(SearchTeacherRequest request)
        {
            return null;
        }
    }
}
