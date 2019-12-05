using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.GetTeacherPerPage
{
    public class GetTeachersPerPageRequestData
    {
        public int TeachersPerPage { get; set; }
        public int PageNumber { get; set; }
    }
}
