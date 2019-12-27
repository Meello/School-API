using System;
using System.Collections.Generic;
using System.Linq;
using School.Core.Filters;
using School.Core.Models;
using StoneCo.Buy4.School.Core.DTO;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using StoneCo.Buy4.School.DataContracts.Subscription.InformationsSubscription;

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
                Level = teacher.LevelId,
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
                LevelId = requestData.Level,
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

        public EnrolledStudentResponseData BuildFrom(EnrolledStudentData enrolledStudent)
        {
            if(enrolledStudent == null)
            {
                return null;
            }

            return new EnrolledStudentResponseData
            {
                Course = enrolledStudent.Course,
                CourseId = enrolledStudent.CourseId,
                EnrolledStudents = enrolledStudent.EnrolledStudents
            };
        }

        public List<EnrolledStudentResponseData> BuildFrom(IEnumerable<EnrolledStudentData> enrolledStudents)
        {
            if(enrolledStudents.Count() == 0)
            {
                return null;
            }

            return enrolledStudents.Select(model => BuildFrom(model)).ToList();
        }

        public InformationResponseData BuildFrom(SubscriptionInformationData subscriptionInformation)
        {
            if(subscriptionInformation == null)
            {
                return null;
            }

            return new InformationResponseData
            {
                ClassId = subscriptionInformation.ClassId,
                Course = subscriptionInformation.Course,
                InformationArea = subscriptionInformation.InformationArea,
                Local = subscriptionInformation.Local,
                Profile = subscriptionInformation.Profile,
                StartDate = DateTime.Parse(subscriptionInformation.StartDate.ToString()).ToString("dd/MM/yy"),
                StartTime = DateTime.Parse(subscriptionInformation.StartTime.ToString()).ToString("hh:mm"),
                Student = subscriptionInformation.Student,
                Teacher = subscriptionInformation.Teacher
            };
        }

        public List<InformationResponseData> BuildFrom(IEnumerable<SubscriptionInformationData> subscriptionInformation)
        {
            if (subscriptionInformation.Count() == 0)
            {
                return null;
            }

            return subscriptionInformation.Select(model => BuildFrom(model)).ToList();
        }

        public ClassInputDto BuildFrom(string line)
        {
            string[] splittedLine = line.Split(';');
            string[] date = splittedLine[4].Split(' ');

            if (splittedLine.Count() == 0)
            {
                return null;
            }

            return new ClassInputDto
            {
                Id = Convert.ToInt32(splittedLine[0]),
                Local = splittedLine[1],
                Teacher = splittedLine[2],
                Course = splittedLine[3],
                Shift = splittedLine[4].Substring(0, 1),
                StartDate = DateTime.Parse(date[0]),
                EndDate = DateTime.Parse(date[2]),
                StartTime = TimeSpan.Parse(splittedLine[5]),
                EndTime = TimeSpan.Parse(splittedLine[5]).Add(TimeSpan.Parse(splittedLine[6]))
            };
        }

        public List<ClassInputDto> BuildFrom(List<string> lines)
        {
            if(lines.Count() == 0)
            {
                return null;
            }

            return lines.Select(model => BuildFrom(model)).ToList();
        }
    }
}

//return new SchoolClass
//{
    //Local = null, //Não tem o campo Local
    ////Buscar no banco
    //CourseId = Convert.ToByte(splittedLine[2]),
    //TeacherId = Convert.ToInt64(splittedLine[1]),
    //Shift = splittedLine[3].Substring(0, 1),
    //StartDate = DateTime.Parse(date[0]),
    //EndDate = DateTime.Parse(date[2]),
    //StartTime = TimeSpan.Parse(splittedLine[5]),
    ////TimeSpan tem metodo para somar horas
    //EndTime = TimeSpan.Parse(splittedLine[5]).Add(addHour)
//};
