using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;

namespace School.Core.Operations.UpdateTeacher
{
    public class UpdateTeacher : OperationBase<UpdateTeacherRequest, UpdateTeacherResponse>, IUpdateTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly ITeacherValidator _teacherValidator;

        public UpdateTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, ITeacherValidator validator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._teacherValidator = validator;
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
            UpdateTeacherResponse response = new UpdateTeacherResponse();

            if(request.Data == null)
            {
                response.AddError("001", "Request can't be null");

                return response;
            }

            if (this._teacherRepository.ExistByTeacherId(request.Data.TeacherId) == false)
            {
                response.Errors.Add(new OperationError("003", $"{nameof(request.Data.TeacherId)} not found"));

                return response;
            }

            if (this._teacherValidator.ValidateTeacher(request.Data, response) == false)
            {
                return response;
            }

            return response;
        }
    }
}
