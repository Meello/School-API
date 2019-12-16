using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.SearchTeacher
{
    public class SearchTeacherRequest : OperationRequestBase
    {
        public SearchTeacherRequest(RequestFilter requestData, long pageNumber, long pageSize)
        {
            Data = requestData;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public long PageNumber {get; set; }

        public long PageSize { get; set; }

        public RequestFilter Data { get; }
    }
}
