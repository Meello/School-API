using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators.DataBaseValidator;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.GetTeacher
{
    public class GetTeacher : OperationBase<GetTeacherRequest, GetTeacherResponse>, IGetTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly IDataBaseValidator _dataBaseValidator;

        public GetTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, IDataBaseValidator dataBaseValidator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._dataBaseValidator = dataBaseValidator;
        }
        
        protected override GetTeacherResponse ProcessOperation(GetTeacherRequest request)
        {
            GetTeacherResponse response = new GetTeacherResponse();

            Teacher teacher = this._teacherRepository.Get(request.CPF);

            response.Data = this._mappingResolver.BuildFrom(teacher);

            return response;
        }

        protected override GetTeacherResponse ValidateOperation(GetTeacherRequest request)
        {
            GetTeacherResponse response = new GetTeacherResponse();

            if (this._dataBaseValidator.ValidateIdExist(request.CPF) == false)
            {
                response.AddError("","");
            }

            return response;
        }
    }
}
