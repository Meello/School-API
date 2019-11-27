using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
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

        public GetTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }
        
        public GetTeacherResponse ProcessOperation(GetTeacherRequest request)
        {
            GetTeacherResponse response = new GetTeacherResponse
            {
                Success = false
            };

            Teacher teacher = this._teacherRepository.Get(request.Id);
            
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
