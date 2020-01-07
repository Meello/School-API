using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Filters
{
    public class TeacherFilter
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
