using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.GetTeachers;

//CUIDADO COM O STARTUP
//TEM QUE LEMBRAR DE REGISTRAR O SERVIÇO NO STARTUP SE NÃO, NÃO FUNCIONA

namespace School.Core.Operations.GetTeachers
{
    public class GetTeachers : IGetTeachers
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public GetTeachers(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }
        
        public GetTeachersResponse ProcessOperation()
        {
            GetTeachersResponse response = new GetTeachersResponse();
            //Default do booleano é falso, logo, não precisa colocar a estrutura do GetTeacher

            List<Teacher> teachers = this._teacherRepository.ListAll();
            //CUIDADO COM PARÊNTESES

            response.Data = this._mappingResolver.BuildFrom(teachers);

            response.Success = true;

            return response;
        }

    }
}
