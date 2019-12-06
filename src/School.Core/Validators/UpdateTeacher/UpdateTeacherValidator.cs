using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using School.Core.Models;
using School.Core.Mapping;
using School.Core.ValidatorsTeacher;

namespace School.Core.Validators.UpdateTeacher
{
    public class UpdateTeacherValidator : IUpdateTeacherValidator
    {
        private readonly ITeacherValidator _teacherValidator;
        private readonly ISchoolMappingResolver _mappingResolver;

        public UpdateTeacherValidator(ITeacherValidator teacherValidator, ISchoolMappingResolver mappingResolver)
        {
            this._teacherValidator = teacherValidator;
            this._mappingResolver = mappingResolver;
        }

        public UpdateTeacherResponse ValidateOperation(UpdateTeacherRequest request)
        {
            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            UpdateTeacherResponse response = new UpdateTeacherResponse();

            if (this._teacherValidator.ValidateTeacher(teacher, response) == false)
            {
                response.Success = false;
                return response;
            }

            response.Success = true;
            return response;
        }
    }
}
