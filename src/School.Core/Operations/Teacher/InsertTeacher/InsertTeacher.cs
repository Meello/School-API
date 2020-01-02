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

            if(request.Datas.Count() > ModelConstants.Teacher.MaxTeachersInList)
            {
                response.AddError("021", "Number of teachers in list exceeded the limit");

                return response;
            }

            List<Teacher> teachers = this._mappingResolver.BuildFrom(request.Datas);

            foreach (Teacher teacher in teachers)
            {
                this._teacherValidator.ValidateTeacher(teacher, response);

                if(!response.Success)
                {
                    response.Errors.Insert(0, new OperationError("000",$"Error!! Value(s) in teacher {teacher.TeacherId} is invalid(s)"));

                    return response;
                }
            }

            foreach(Teacher teacher in teachers)
            {
                if (this._teacherRepository.ExistByTeacherId(teacher.TeacherId) == true)
                {
                    response.AddError("013", $"{nameof(teacher.TeacherId)} of teacher Id:{teacher.TeacherId} already exist");

                    return response;
                }
            }

            return response;
        }
    }
}