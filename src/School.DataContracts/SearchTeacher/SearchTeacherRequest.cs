using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.FilterTeacher
{
    public class SearchTeacherRequest
    {
        public SearchTeacherRequest(SearchTeacherRequestData requestData)
        {
            Data = requestData;
        }

        public SearchTeacherRequestData Data { get; }
    }
}
