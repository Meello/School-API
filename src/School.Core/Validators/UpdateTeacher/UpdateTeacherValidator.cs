using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using School.Core.Models;
using School.Core.Mapping;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts;
using System.Collections.Generic;

namespace School.Core.Validators.UpdateTeacher
{
    public class UpdateTeacherValidator : IUpdateTeacherValidator
    {
        private readonly ITeacherValidator _teacherValidator;

        public UpdateTeacherValidator(ITeacherValidator teacherValidator)
        {
            this._teacherValidator = teacherValidator;
        }

        public UpdateTeacherResponse ValidateOperation(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = new UpdateTeacherResponse();

            if (this._teacherValidator.ValidateTeacher(request.Data, response) == false)
            {
                return response;
            }

            return response;
        }
    }
}
