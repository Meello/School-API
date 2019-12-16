using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.GetTeacher
{
    public class GetTeacher : OperationBase<GetTeacherRequest, GetTeacherResponse>, IGetTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public GetTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }
        
        protected override GetTeacherResponse ProcessOperation(GetTeacherRequest request)
        {
            GetTeacherResponse response = new GetTeacherResponse();

            Teacher teacher = this._teacherRepository.Get(request.TeacherId);

            response.Data = this._mappingResolver.BuildFrom(teacher);

            return response;
        }

        protected override GetTeacherResponse ValidateOperation(GetTeacherRequest request)
        {
            GetTeacherResponse response = new GetTeacherResponse();

            if (this._teacherRepository.ExistByTeacherId(request.TeacherId) == false)
            {
                response.AddError("003","TeacerId not found");
            }

            return response;
        }
    }
}
