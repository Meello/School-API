using School.Core.Models;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
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

        List<TeacherResponseData> BuildFrom(IEnumerable<Models.Teacher> teacher);

        Teacher BuildFrom(UpdateTeacherRequestData data);
    }
}
