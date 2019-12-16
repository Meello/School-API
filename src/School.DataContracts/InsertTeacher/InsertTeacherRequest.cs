using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.InsertTeacher
{
    public class InsertTeacherRequest : OperationRequestBase
    {      
        public InsertTeacherRequest(TeacherRequestData requestData)
        {
            Data = requestData;
        }

        public TeacherRequestData Data { get; }
    }
}
