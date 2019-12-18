using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators.InsertAndUpdate;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;

namespace School.Core.Operations.UpdateTeacher
{
    public class UpdateTeacher : OperationBase<UpdateTeacherRequest, UpdateTeacherResponse>, IUpdateTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IInsertAndUpdateValidator<UpdateTeacherResponse> _validator;

        public UpdateTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IInsertAndUpdateValidator<UpdateTeacherResponse> validator)
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
            UpdateTeacherResponse response = this._validator.ValidateInsertAndUpdate(request.Data);

            return response;
        }
    }
}
