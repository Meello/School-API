using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.UpdateTeacher
{
    public class UpdateTeacherRequest
    {       
        public UpdateTeacherRequest(UpdateTeacherRequestData requestData)
        {
            Data = requestData;
        }

        public UpdateTeacherRequestData Data { get; }
    }
}
