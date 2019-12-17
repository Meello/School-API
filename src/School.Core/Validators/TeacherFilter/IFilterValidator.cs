using School.Core.Filters;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.TeacherFilter
{
    public interface IFilterValidator
    {
        SearchTeacherResponse ValidateParameters(RequestFilter requestFilter);
    }
}
