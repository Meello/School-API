using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Querys.SearchConditions
{
    public interface ISearchConditions
    {
        string SqlStringSearchConditions(SearchTeacherRequestData resquestData);
    }
}
