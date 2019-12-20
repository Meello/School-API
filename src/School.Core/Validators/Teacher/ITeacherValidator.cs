using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.ValidatorsTeacher
{
    public interface ITeacherValidator
    {
        void ValidateTeacher(Teacher teacher, OperationResponseBase response);
    }
}
