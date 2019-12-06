using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.UpdateTeacher
{
    public interface IUpdateTeacherValidator
    {
        UpdateTeacherResponse ValidateOperation(UpdateTeacherRequest request);
    }
}
