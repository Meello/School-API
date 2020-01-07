using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.SearchTeacher
{
    public class RequestFilter
    {
        public string Name { get; set; }

        public List<char> Genders { get; set; }

        public List<char> LevelIds { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }

        public DateTime? MinAdmitionDate { get; set; }

        public DateTime? MaxAdmitionDate { get; set; }
    }
}
