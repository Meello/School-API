using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.SearchTeacher
{
    public interface ISearchTeacher
    {
        SearchTeacherResponse ProcessOperation(SearchTeacherRequest request);
    }
}
