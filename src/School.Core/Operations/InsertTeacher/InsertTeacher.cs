using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System.Collections.Generic;

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

            List<Teacher> teachers = this._mappingResolver.BuildFrom(request.Datas.RequestDatas);

            //Falta passar a lista dentro do insert
            this._teacherRepository.Insert(teachers);

            return response;
        }

        protected override InsertTeacherResponse ValidateOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = new InsertTeacherResponse();

            this._teacherValidator.ValidateTeacher(request.Datas, response);

            if (!response.Success)
            {
                return response;
            }

            if (this._teacherRepository.ExistByTeacherId(request.Datas.RequestDatas) == true)
            {
                response.AddError("013", $"{nameof(request.Datas.TeacherId)} already exist");

                return response;
            }

            return response;
        }
    }
}
