using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators
{
    public interface IInsertTeacherValidator
    {
        InsertTeacherResponse ValidateOperation(InsertTeacherRequest request);
    }

}
