using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Models
{
    public class Class
    {
		public int ClassId { get; set; }

		public string Local { get; set; }
		
		public int CourseId { get; set; }
		
		public Int64 TeacherId { get; set; }

		public string Shift { get; set; }
		
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
	
		public TimeSpan StartTime { get; set; }
		
		public TimeSpan EndTime { get; set; }
	}
}
