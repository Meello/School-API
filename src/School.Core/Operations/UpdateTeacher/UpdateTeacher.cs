using System;
using System.Collections.Generic;
using System.Text;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;

namespace School.Core.Operations.UpdateTeacher
{
    public class UpdateTeacher : IUpdateTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public UpdateTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }

        public UpdateTeacherResponse ProcessOperation(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = new UpdateTeacherResponse();

            Teacher teacher = this._teacherRepository.Update(request.Id, request.Name, request.Gender, request.LevelId, request.Salary, request.AdmitionDate);

            if (request == null)
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
