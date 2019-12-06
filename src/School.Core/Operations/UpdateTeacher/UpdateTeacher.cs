using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators.IdValidator;
using School.Core.Validators.UpdateTeacher;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;

namespace School.Core.Operations.UpdateTeacher
{
    public class UpdateTeacher : IUpdateTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IUpdateTeacherValidator _validator;
        private readonly IDataBaseValidator _dataBaseValidator;

        public UpdateTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IUpdateTeacherValidator validator, IDataBaseValidator dataBaseValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
            this._dataBaseValidator = dataBaseValidator;
        }

        public UpdateTeacherResponse ProcessOperation(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = this._validator.ValidateProcess(request);

            if (response.Success == false)
            {
                return response;
            }

            if(this._dataBaseValidator.ValidateIdExist(request.Data.CPF) == false)
            {
                response.Errors.Add(new OperationError("003", "CPF not found"));
                response.Success = false;
                return response;
            }

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            this._teacherRepository.Update(teacher);

            response.Success = true;

            return response;
        }
    }
}
