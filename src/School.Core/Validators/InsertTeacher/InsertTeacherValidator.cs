using School.Core.Mapping;
using School.Core.Models;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System.Collections.Generic;

namespace School.Core.Validators
{
    public class InsertTeacherValidator : IInsertTeacherValidator
    {
        private readonly ITeacherValidator _teacherValidator;
        private readonly ISchoolMappingResolver _mappingResolver;

        public InsertTeacherValidator(ITeacherValidator teacherValidator, ISchoolMappingResolver mappingResolver)
        {
            this._teacherValidator = teacherValidator;
            this._mappingResolver = mappingResolver;
        }

        public InsertTeacherResponse ValidateOperation(InsertTeacherRequest request)
        {
            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            InsertTeacherResponse response = new InsertTeacherResponse
            {
                Errors = new List<OperationError>()
            };

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
