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

        public UpdateTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, ITeacherValidator teacherValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._teacherValidator = teacherValidator;
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

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            this._teacherValidator.ValidateTeacher(teacher, response);

            if(!response.Success)
            {
                return response;
            }

            if (this._teacherRepository.ExistByTeacherId(teacher.TeacherId) == false)
            {
                response.Errors.Add(new OperationError("003", $"{nameof(teacher.TeacherId)} not found"));

                return response;
            }

            return response;
        }
    }
}
