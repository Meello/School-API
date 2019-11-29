using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
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

        public UpdateTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IUpdateTeacherValidator validator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
        }

        public UpdateTeacherResponse ProcessOperation(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = new UpdateTeacherResponse
            {
                Errors = new List<OperationError>()
            };

            this._validator.ValidateFormat(request, response);

            if(response.Success == false)
            {
                return response;
            }

            UpdateTeacherRequestData teacher = this._mappingResolver.BuildFrom(request.Data);

            //O objeto para ser passado para o BuildFrom deve ser o que recebe o repositório
            //Tomar cuidado para não enviar a requisição
            Teacher updatedTeacher = this._teacherRepository.Update(teacher);

            this._validator.ValidateBusinessRules(request, response);

            response.Data = this._mappingResolver.BuildFrom(updatedTeacher);
            response.Success = true;

            return response;
        }
    }
}
