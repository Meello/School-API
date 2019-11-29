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
                CPF = 1,
                Name = "Bruno",
                Gender = 'M',
                Level = 'S',
                Salary = 1000.00m, //m para dizer que é decimal
                AdmitionDate = DateTime.Now
            }
        };

        public Teacher Delete(long cpf)
        {
            for (int i = 0; i < _teachers.Count; i++)
            {
                if (_teachers[i].CPF == cpf)
                {
                    Teacher teacher = _teachers.ElementAt(i);
                    _teachers.Remove(teacher);
                    return teacher;
                }
            }

            return null;
        }

        public Teacher Get(long cpf)
        {
            for (int i = 0; i < _teachers.Count; i++)
            {
                if (_teachers[i].CPF == cpf)
                {
                    Teacher teacher = _teachers.ElementAt(i);
                    return teacher;
                }
            }
            return null;
        }

        public Teacher Insert(Teacher teacherToInsert)
        {
            _teachers.Add(teacherToInsert);

            return teacherToInsert;
        }

        public List<Teacher> ListAll()
        {
            return _teachers;
        }

        public Teacher Update(UpdateTeacherRequestData requestData)
        {
            if (_teachers.Find(x => x.CPF == requestData.CPF) == null)
            {
                return null;
            }
            
            for (int i = 0; i < _teachers.Count; i++)
            {
                if (_teachers[i].CPF == requestData.CPF)
                {
                    _teachers[i].AdmitionDate = requestData.AdmitionDate.Value;
                    _teachers[i].Gender = requestData.Gender.Value;
                    _teachers[i].Level = requestData.Level.Value;
                    _teachers[i].Name = requestData.Name;
                    _teachers[i].Salary = requestData.Salary.Value;
                }
            }

            return _teachers.Find(x => x.CPF == requestData.CPF);
        }
    }
}
