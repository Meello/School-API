using School.Core.Filters;
using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Mapping
{
    public interface ISchoolMappingResolver
    {
        TeacherResponseData BuildFrom(Teacher teacher);

        Teacher BuildFrom(TeacherRequestData requestData);

        List<TeacherResponseData> BuildFrom(IEnumerable<Teacher> teacher);

        TeacherFilter BuildFrom(RequestFilter requestFilter);

        //TeacherResponseData BuildFrom(PagedResult<Teacher> teachers);
    }
}
