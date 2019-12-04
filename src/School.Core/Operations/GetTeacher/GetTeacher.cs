using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators.IdValidator;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.GetTeacher
{
    public class GetTeacher : IGetTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IIdExistValidator _idExistValidator;

        public GetTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IIdExistValidator idExistValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._idExistValidator = idExistValidator;
        }
        
        public GetTeacherResponse ProcessOperation(GetTeacherRequest request)
        {
            GetTeacherResponse response = new GetTeacherResponse
            {
                Success = false
            };

            if (this._idExistValidator.ValidateIdExist(request.CPF) == false)
            {
                response.Success = false;
                return response;
            }

            Teacher teacher = this._teacherRepository.Get(request.CPF);
            
            if(teacher is null)
            {
                response.Success = false;
                return response;
            }

            response.Data = this._mappingResolver.BuildFrom(teacher);
            response.Success = true;

            return response;
        }
    }
}
