using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators.InsertAndUpdate;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;

namespace School.Core.Operations.InsertTeacher
{
    public class InsertTeacher : OperationBase<InsertTeacherRequest, InsertTeacherResponse>, IInsertTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IInsertAndUpdateValidator<InsertTeacherResponse> _validator;

        public InsertTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IInsertAndUpdateValidator<InsertTeacherResponse> validator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
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
            InsertTeacherResponse response = this._validator.ValidateInsertAndUpdate(request.Data);

            return response;
        }
    }
}
