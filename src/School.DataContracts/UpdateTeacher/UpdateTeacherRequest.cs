using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.UpdateTeacher
{
    public class UpdateTeacherRequest
    {       
        public UpdateTeacherRequest(long id, string name, char gender, char levelId, decimal salary, DateTime admitionDate)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.LevelId = levelId;
            this.Salary = salary;
            this.AdmitionDate = admitionDate;
        }

        public long Id { get; }

        public string Name { get;}

        public char Gender { get;}

        public char LevelId { get; }

        public decimal Salary { get; }

        public DateTime AdmitionDate { get;}
    }
}
