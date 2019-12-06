using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators;
using School.Core.Validators.IdValidator;
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
        private readonly IDataBaseValidator _idExistValidator;

        public InsertTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IInsertTeacherValidator validator, IDataBaseValidator idExistValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
            this._idExistValidator = idExistValidator;
        }

        public InsertTeacherResponse ProcessOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = this._validator.ValidateOperation(request);

            if(response.Success == false)
            {
                return response;
            }

            if(this._idExistValidator.ValidateIdExist(request.Data.CPF) == true)
            {
                response.Errors.Add(new OperationError("013", "CPF already exist"));
                response.Success = false;
                return response;
            }

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            this._teacherRepository.Insert(teacher);

            response.Success = true;

            return response;
        }
    }
}
