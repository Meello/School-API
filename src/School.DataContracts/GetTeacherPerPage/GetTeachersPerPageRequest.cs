using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.GetTeacherPerPage
{
    public class GetTeachersPerPageRequest
    {
        public GetTeachersPerPageRequest(GetTeachersPerPageRequestData requestData)
        {
            Data = requestData;
        }

        public GetTeachersPerPageRequestData Data { get; set; }
    }
}
