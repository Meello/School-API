using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.GetTeacherPerPage
{
    public class GetTeachersPerPageRequest
    {
        public GetTeachersPerPageRequest(long pageNumber, long pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public long PageNumber { get; set; }

        public long PageSize { get; set; }
    }
}
