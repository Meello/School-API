using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.FilterTeacher
{
    public class SearchTeacherRequestData
    {
        public long? CPF { get; set; }

        public string Name { get; set; }

        public List<char?> Gender { get; set; }

        public List<char?> Level { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }

        public DateTime? MinAdmitionDate { get; set; }

        public DateTime? MaxAdmitionDate { get; set; }
    }
}
