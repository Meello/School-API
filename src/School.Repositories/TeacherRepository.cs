using School.Core.Models;
using School.Core.Repositories;
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
                LevelId = 'S',
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
            _teachers.Add(teacherToInsert);

            return teacherToInsert;
        }

        public List<Teacher> ListAll()
        {
            return _teachers;
        }

        //Update é teacher ou boolean?
        public Teacher Update(long id, string name, char? gender, char? levelId, decimal? salary, DateTime? admitionDate)
        {
            if (id <= 0)
            {
                throw new Exception();
            }

            Teacher teacherToUpdate = _teachers.Find(x => x.Id == id) ;

            if(!string.IsNullOrWhiteSpace(name))
            {
                teacherToUpdate.Name = name;
            }

            if (gender != '\u0000'|| gender == 'F' || gender == 'M')
            {
                teacherToUpdate.Gender = gender.Value;
            }

            if (levelId != '\u0000' || levelId == 'J' || levelId == 'P' || levelId == 'S')
            {
                teacherToUpdate.LevelId = levelId.Value;
            }

            if (salary != decimal.Zero)
            {
                teacherToUpdate.Salary = salary.Value;
            }

            if(admitionDate != DateTime.MinValue)
            {
                teacherToUpdate.AdmitionDate = admitionDate.Value;
            }

            return teacherToUpdate;
        }
    }
}
