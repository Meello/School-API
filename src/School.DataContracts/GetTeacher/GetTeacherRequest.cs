using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.GetTeacher
{
    public class GetTeacherRequest
    {
        public GetTeacherRequest(long id)
        {
            this.Id = id;
        }

        public long Id{ get; }
    }
}
