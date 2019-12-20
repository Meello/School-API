using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Models
{
    public class Teacher
    {
        public long TeacherId { get; set; }
        
        public string Name { get; set; }
        
        public char Gender { get; set; }
        
        public char LevelId { get; set; }
        
        public decimal Salary { get; set; }
        
        public DateTime AdmitionDate { get; set; }
    }
}
