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
            //Criar objeto response para retornar os valores
            DeleteTeacherResponse response = new DeleteTeacherResponse();

            //Criar objeto teacher da classe Teacher para receber os valores correspondentes da requisição
            //Requisição --> request
            //Delete --> verbo usado para deletar o teacher requisitado
            //request. para pegar o valor do objeto request da classe DeleteTeacherRequest
            Teacher teacher = this._teacherRepository.Delete(request.CPF);

            //Conferir se a requisição é nula ou não exista no banco de dados
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
