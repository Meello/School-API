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
    public class UpdateTeacher : OperationBase<UpdateTeacherRequest, UpdateTeacherResponse>, IUpdateTeacher
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

        protected override UpdateTeacherResponse ProcessOperation(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = new UpdateTeacherResponse();

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            this._teacherRepository.Update(teacher);

            return response;
        }

        protected override UpdateTeacherResponse ValidateOperation(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = this._validator.ValidateOperation(request);

            if (this._teacherRepository.ExistByTeacherId(request.Data.TeacherId) == false)
            {
                response.Errors.Add(new OperationError("003", "CPF not found"));
            }

            return response;
        }
    }
}
