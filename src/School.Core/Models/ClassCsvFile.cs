using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Models
{
    public class ClassCsvFile
    {
        public int Id { get; set; }

        public string Teacher { get; set; }

        public string Course { get; set; }

        public string Shift { get; set; }

        public string Period { get; set; }

        public TimeSpan StartTime { get; set; }

        public int DurationInHours { get; set; }
    }
}
