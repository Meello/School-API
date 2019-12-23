using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.DeleteTeacher
{
    public class DeleteTeacherRequest : OperationRequestBase
    {
        public DeleteTeacherRequest(long teacherId)
        {
            this.TeacherId = teacherId;
        }

        public long TeacherId { get; }
    }
}
