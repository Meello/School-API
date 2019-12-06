using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.GetTeacherPerPage
{
    public class GetTeachersPerPageRequest
    {
        public GetTeachersPerPageRequest(long pageNumber, long teachersPerPage)
        {
            PageNumber = pageNumber;
            TeachersPerPage = teachersPerPage;
        }

        public long PageNumber { get; set; }

        public long TeachersPerPage { get; set; }
    }
}
