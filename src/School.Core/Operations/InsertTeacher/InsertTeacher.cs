using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;

namespace School.Core.Operations.InsertTeacher
{
    public class InsertTeacher : OperationBase<InsertTeacherRequest, InsertTeacherResponse>, IInsertTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly ITeacherValidator _teacherValidator;

        public InsertTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, ITeacherValidator teacherValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._teacherValidator = teacherValidator;
        }

        protected override InsertTeacherResponse ProcessOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = new InsertTeacherResponse();

            Teacher teacher = this._mappingResolver.BuildFrom(request.Data);

            this._teacherRepository.Insert(teacher);

            return response;
        }

        protected override InsertTeacherResponse ValidateOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = new InsertTeacherResponse();

            this._teacherValidator.ValidateTeacher(request.Data, response);

            if (!response.Success)
            {
                return response;
            }

            if (this._teacherRepository.ExistByTeacherId(request.Data.TeacherId) == true)
            {
                response.AddError("013", $"{nameof(request.Data.TeacherId)} already exist");

                return response;
            }

            return response;
        }
    }
}
