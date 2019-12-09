using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.SearchTeacher
{
    public interface ISearchTeacherValidator
    {
        SearchTeacherResponse ValidateParameters(SearchTeacherRequestData requestData);

        void ValidatePage(long maxElements, long elementsPerPage, long pageNumber, SearchTeacherResponse response);
    }
}
