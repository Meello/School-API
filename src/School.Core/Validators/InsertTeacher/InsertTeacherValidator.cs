using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
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
        private readonly ITeacherRepository _teacherRepository;

        public InsertTeacherValidator(ITeacherValidator teacherValidator, ISchoolMappingResolver mappingResolver, ITeacherRepository teacherRepository)
        {
            this._teacherValidator = teacherValidator;
            this._mappingResolver = mappingResolver;
            this._teacherRepository = teacherRepository;
        }

        public InsertTeacherResponse ValidateOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = new InsertTeacherResponse();

            if (this._teacherRepository.ExistByTeacherId(request.Data.TeacherId) == true)
            {
                response.AddError("013", $"{nameof(request.Data.TeacherId)} already exist");

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
