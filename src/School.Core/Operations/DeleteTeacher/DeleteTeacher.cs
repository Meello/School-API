using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.DeleteTeacher
{
    //NÃO PODE ESQUECER DE IMPLEMENTAR O CONTRATO
    public class DeleteTeacher : IDeleteTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public DeleteTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver )
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }

        public DeleteTeacherResponse ProcessOperation(DeleteTeacherRequest request)
        {
            DeleteTeacherResponse response = new DeleteTeacherResponse();

            Teacher teacher = this._teacherRepository.Delete(request.CPF, response);

            if(teacher == null)
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
