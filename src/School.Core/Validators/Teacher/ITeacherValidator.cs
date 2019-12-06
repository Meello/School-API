using School.Core.Models;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.ValidatorsTeacher
{
    public interface ITeacherValidator
    {
        bool ValidateTeacher(Teacher teacher, OperationResponseBase response);
    }
}
