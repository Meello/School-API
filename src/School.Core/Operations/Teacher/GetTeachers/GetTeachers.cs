using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.GetTeachers;

//CUIDADO COM O STARTUP
//TEM QUE LEMBRAR DE REGISTRAR O SERVIÇO NO STARTUP SE NÃO, NÃO FUNCIONA

namespace School.Core.Operations.GetTeachers
{
    public class GetTeachers : OperationBase<GetTeachersRequest, GetTeachersResponse>, IGetTeachers
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public GetTeachers(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }
        
        protected override GetTeachersResponse ProcessOperation(GetTeachersRequest request)
        {
            GetTeachersResponse response = new GetTeachersResponse();

            List<Teacher> teachers = this._teacherRepository.ListAll().ToList();

            response.Data = this._mappingResolver.BuildFrom(teachers);

            return response;
        }

        protected override GetTeachersResponse ValidateOperation(GetTeachersRequest request)
        {
            return new GetTeachersResponse();
        }
    }
}
