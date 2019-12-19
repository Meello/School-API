using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.ValidatorsTeacher;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System.Collections.Generic;
using System.Linq;

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

            List<Teacher> teachers = this._mappingResolver.BuildFrom(request.Datas);

            this._teacherRepository.Insert(teachers);

            return response;
        }

        protected override InsertTeacherResponse ValidateOperation(InsertTeacherRequest request)
        {
            InsertTeacherResponse response = new InsertTeacherResponse();

            foreach (TeacherRequestData teacher in request.Datas)
            {
                this._teacherValidator.ValidateTeacher(teacher, response);

                if(!response.Success)
                {
                    int index = request.Datas.ToList().IndexOf(teacher);
                    response.AddError("000",$"Error in teacher number {index+1}");
                    return response;
                }
            }

            List<Teacher> teachers = this._mappingResolver.BuildFrom(request.Datas);

            foreach(Teacher teacher in teachers)
            {
                if (this._teacherRepository.ExistByTeacherId(teacher.TeacherId) == true)
                {
                    int index = teachers.IndexOf(teacher);
                    response.AddError("013", $"{nameof(teacher.TeacherId)} already exist");
                    response.AddError("000", $"Error in teacher number {index+1}");
                    return response;
                }
            }

            return response;
        }
    }
}