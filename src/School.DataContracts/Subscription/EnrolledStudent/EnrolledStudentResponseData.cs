using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents
{
    public class EnrolledStudentResponseData
    {
        public byte CourseId { get; set; }

        public string Course { get; set; }

        public int EnrolledStudents { get; set; }
    }
}
