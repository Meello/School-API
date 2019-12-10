using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.SearchTeacher
{
    public interface ISearchTeacherValidator
    {
        SearchTeacherResponse ValidateParameters(SearchTeacherRequest request);

        void ValidatePage(long maxElements, long? pageSize, long? pageNumber, SearchTeacherResponse response);
    }
}
