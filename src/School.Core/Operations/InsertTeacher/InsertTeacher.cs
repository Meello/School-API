using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.InsertTeacher
{
    public class InsertTeacher : IInsertTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;

        public InsertTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
        }

        public InsertTeacherResponse ProcessOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = ValidateOperation(request);

            if(response.Success == false)
            {
                return response;
            }

            //InsertTeacherResponse response = new InsertTeacherResponse();

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            this._teacherRepository.Insert(teacher);

            if(request == null)
            {
                response.Success = false;
                return response;
            }

            response.Data = this._mappingResolver.BuildFrom(teacher);
            response.Success = true;

            return response;
        }

        private InsertTeacherResponse ValidateOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = new InsertTeacherResponse
            {
                Errors = new List<OperationError>()
            };

            if (request.Data == null)
            {
                response.Errors.Add(new OperationError("001", "Request não pode ser nulo"));
                return response;
            }

            response.Success = true;

            return response;
        }
    }
}
