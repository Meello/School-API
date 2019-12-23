using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.UpdateTeacher
{
    public class UpdateTeacherRequest : OperationRequestBase
    {       
        public UpdateTeacherRequest(TeacherRequestData requestData)
        {
            Data = requestData;
        }

        public TeacherRequestData Data { get; }
    }
}
