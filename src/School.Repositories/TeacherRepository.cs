using School.Core.Models;
using School.Core.Repositories;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private static List<Teacher> _teachers = new List<Teacher> 
        //Para private static usar _ e nome em minúsculo
        {
            new Teacher
            {
                Id = 1,
                Name = "Bruno",
                Gender = 'M',
                Level = 'S',
                Salary = 1000.00m, //m para dizer que é decimal
                AdmitionDate = DateTime.Now
            }
        };

        public Teacher Delete(long id)
        {
            for (int i = 0; i < _teachers.Count; i++)
            {
                if (_teachers[i].Id == id)
                {
                    Teacher teacher = _teachers.ElementAt(i);
                    _teachers.Remove(teacher);
                    return teacher;
                }
            }

            return null;
        }

        public Teacher Get(long id)
        {
            for (int i = 0; i < _teachers.Count; i++)
            {
                if (_teachers[i].Id == id)
                {
                    Teacher teacher = _teachers.ElementAt(i);
                    return teacher;
                }
            }
            return null;
        }

        public Teacher Insert(Teacher teacherToInsert)
        {
            if (_teachers.Find(x => x.Id == teacherToInsert.Id) == null)
            {
                teacherToInsert.Id = -1;
                return teacherToInsert;
            }
            
            _teachers.Add(teacherToInsert);

            return teacherToInsert;
        }

        public List<Teacher> ListAll()
        {
            return _teachers;
        }

        public Teacher Update(UpdateTeacherRequestData requestData)
        {
            if (requestData.Id == 0)
            {
                return new Teacher 
                {
                    Id = requestData.Id
                };
            }
            Teacher teacherToUpdate = _teachers.Find(x => x.Id == requestData.Id);

            if(teacherToUpdate == null)
            {
                return null;
            }

            if(!string.IsNullOrWhiteSpace(requestData.Name))
            {
                teacherToUpdate.Name = requestData.Name;
            }

            if (requestData.Gender != null|| requestData.Gender == 'F' || requestData.Gender == 'M')
            {
                teacherToUpdate.Gender = requestData.Gender.Value;
            }

            if (requestData.Level != null || requestData.Level == 'J' || requestData.Level == 'P' || requestData.Level == 'S')
            {
                teacherToUpdate.Level = requestData.Level.Value;
            }

            if (requestData.Salary != null)
            {
                teacherToUpdate.Salary = requestData.Salary.Value;
            }

            if(requestData.AdmitionDate != null)
            {
                teacherToUpdate.AdmitionDate = requestData.AdmitionDate.Value;
            }

            return teacherToUpdate;
        }
    }
}
