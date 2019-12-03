using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.InsertTeacher
{
    public class InsertTeacher : IInsertTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IInsertTeacherValidator _validator;

        public InsertTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IInsertTeacherValidator validator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
        }

        public InsertTeacherResponse ProcessOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = this._validator.ValidateOperation(request);

            if(response.Success == false)
            {
                return response;
            }

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            Teacher insertedTeacher = this._teacherRepository.Insert(teacher, response);

            response.Data = this._mappingResolver.BuildFrom(insertedTeacher);
            response.Success = true;

            return response;
        }
    }
}
