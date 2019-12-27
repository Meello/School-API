using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.Core.DTO
{
    public class ClassInputDto
    {
        public int Id { get; set; }

        public string Local { get; set; }

        public string Teacher { get; set; }

        public string Course { get; set; }

        public string Shift { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
