using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.UpdateTeacher
{
    public interface IUpdateTeacher
    {
        UpdateTeacherResponse ProcessOperation(UpdateTeacherRequest request);
    }
}
