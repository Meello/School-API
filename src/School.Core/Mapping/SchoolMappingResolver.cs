﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
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
                Id = teacher.Id,
                Name = teacher.Name,
                Gender = teacher.Gender,
                Level = teacher.Level,
                Salary = teacher.Salary,
                AdmitionDate = teacher.AdmitionDate
            };
        }



        public List<TeacherResponseData> BuildFrom(List<Teacher> teachers)
            //sobrecarga de método --> capacidade de um método ter o mesmo nome com assinaturas diferentes
            //variando o tipo e a quantidade de variáveis
        {
            if(teachers == null)
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
                Id = requestData.Id,
                Name = requestData.Name,
                Gender = requestData.Gender,
                Level = requestData.Level,
                Salary = requestData.Salary,
                AdmitionDate = requestData.AdmitionDate
            };
        }
        
        public UpdateTeacherRequestData BuildFrom(UpdateTeacherRequestData requestData)
        {
            if (requestData == null)
            {
                return null;
            }

            return new UpdateTeacherRequestData
            {                
                Id = requestData.Id,
                Name = requestData.Name,
                Gender = requestData.Gender,
                Level = requestData.Level,
                Salary = requestData.Salary,
                AdmitionDate = requestData.AdmitionDate
            };
        }
        
    }
}
