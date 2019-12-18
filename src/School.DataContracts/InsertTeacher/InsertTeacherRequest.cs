using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.InsertTeacher
{
    public class InsertTeacherRequest : OperationRequestBase
    {      
        public InsertTeacherRequest(TeacherRequestDatas requestDatas)
        {
            Datas = requestDatas;
        }

        public TeacherRequestDatas Datas { get; }
    }
}
