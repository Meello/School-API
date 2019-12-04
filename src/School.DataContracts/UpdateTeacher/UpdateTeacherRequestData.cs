using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.UpdateTeacher
{
    public class UpdateTeacherRequestData
    {
        public long CPF { get; set; }

        public string Name { get; set; }

        public char Gender { get; set; }

        public char Level { get; set; }

        public decimal Salary { get; set; }

        public DateTime AdmitionDate { get; set; }
    }
}
