using StoneCo.Buy4.School.DataContracts.FilterTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.FilterTeacher
{
    public interface ISearchTeacher
    {
        SearchTeacherResponse ProcessOperation(SearchTeacherRequest request);
    }
}
