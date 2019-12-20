using System.Collections.Generic;
using System.Linq;
using School.Core.Filters;
using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;

namespace School.Core.Mapping
{
    public class SchoolMappingResolver : ISchoolMappingResolver
    {
        public TeacherResponseData BuildFrom(Teacher teacher)
        {
            if(teacher == null)
            {
                return null;
            }

            return new TeacherResponseData
            {
                TeacherId = teacher.TeacherId,
                Name = teacher.Name,
                Gender = teacher.Gender,
                Level = teacher.Level,
                Salary = teacher.Salary,
                AdmitionDate = teacher.AdmitionDate
            };
        }

        public List<TeacherResponseData> BuildFrom(IEnumerable<Teacher> teachers)
            //sobrecarga de método --> capacidade de um método ter o mesmo nome com assinaturas diferentes
            //variando o tipo e a quantidade de variáveis
        {
            if(teachers.Count<Teacher>() == 0)
            {
                return null;
            }

            return teachers.Select(model => BuildFrom(model)).ToList();
        }

        public Teacher BuildFrom(TeacherRequestData requestData)
        {
            if(requestData == null)
            {
                return null;
            }

            return new Teacher
            {
                TeacherId = requestData.TeacherId,
                Name = requestData.Name,
                Gender = requestData.Gender,
                Level = requestData.Level,
                Salary = requestData.Salary,
                AdmitionDate = requestData.AdmitionDate
            };
        }

        public List<Teacher> BuildFrom(IEnumerable<TeacherRequestData> requestDatas)
        {
            if(requestDatas.Count()== 0)
            {
                return null;
            }

            return requestDatas.Select(model => BuildFrom(model)).ToList();
        }

        public TeacherFilter BuildFrom(RequestFilter requestFilter)
        {
            if(requestFilter == null)
            {
                return null;
            }

            return new TeacherFilter
            {
                Genders = requestFilter.Genders,
                LevelIds = requestFilter.LevelIds,
                MaxAdmitionDate = requestFilter.MaxAdmitionDate,
                MinAdmitionDate = requestFilter.MinAdmitionDate,
                MaxSalary = requestFilter.MaxSalary,
                MinSalary = requestFilter.MinSalary,
                Name = requestFilter.Name
            };
        }
    }
}
