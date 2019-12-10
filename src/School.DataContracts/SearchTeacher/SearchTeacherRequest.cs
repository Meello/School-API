using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.SearchTeacher
{
    public class SearchTeacherRequest
    {
        public SearchTeacherRequest(SearchTeacherRequestData requestData, long pageSize, long pageNumber)
        {
            Data = requestData;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public long PageSize { get; }

        public long PageNumber { get; }

        public SearchTeacherRequestData Data { get; }
    }
}
