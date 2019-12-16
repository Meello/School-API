using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.InsertTeacher
{
    public interface IInsertTeacher
    {
        InsertTeacherResponse Process(InsertTeacherRequest request);
    }
}
