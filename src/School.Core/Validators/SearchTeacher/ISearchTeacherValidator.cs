using StoneCo.Buy4.School.DataContracts.FilterTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.SearchTeacher
{
    public interface ISearchTeacherValidator
    {
        SearchTeacherResponse ValidateOperation(SearchTeacherRequestData requestData);
    }
}
