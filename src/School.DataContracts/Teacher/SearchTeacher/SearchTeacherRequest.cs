using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.SearchTeacher
{
    public class SearchTeacherRequest : OperationRequestBase
    {
        public SearchTeacherRequest(RequestFilter requestData, int pageNumber, int pageSize)
        {
            Data = requestData;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber {get; set; }

        public int PageSize { get; set; }

        public RequestFilter Data { get; }
    }
}
