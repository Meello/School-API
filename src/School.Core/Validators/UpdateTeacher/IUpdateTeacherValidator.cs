using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.UpdateTeacher
{
    public interface IUpdateTeacherValidator
    {
        UpdateTeacherResponse ValidateFormat(UpdateTeacherRequest request, UpdateTeacherResponse response);
        
        UpdateTeacherResponse ValidateBusinessRules(UpdateTeacherRequest request, UpdateTeacherResponse response);
    }
}
