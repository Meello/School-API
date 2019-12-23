using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.GetTeacher
{
    public class GetTeacherRequest : OperationRequestBase
    {
        public GetTeacherRequest(long teacherId)
        {
            this.TeacherId = teacherId;
        }

        public long TeacherId { get; }
    }
}
