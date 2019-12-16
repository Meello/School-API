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
            InsertTeacherResponse response = new InsertTeacherResponse();

            if (this._teacherValidator.ValidateTeacher(request.Data, response) == false)
            {
                return response;
            }

            return response;
        }
    }
}
