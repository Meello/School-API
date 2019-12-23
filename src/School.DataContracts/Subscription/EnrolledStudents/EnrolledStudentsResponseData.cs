using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents
{
    public class EnrolledStudentsResponseData
    {
        public byte CourseId { get; }

        public string Course { get; }

        public int EnrolledStudents { get; }
    }
}
