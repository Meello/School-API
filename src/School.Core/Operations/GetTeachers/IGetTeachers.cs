using StoneCo.Buy4.School.DataContracts.GetTeachers;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations.GetTeachers
{
    public interface IGetTeachers
    {
        GetTeachersResponse ProcessOperation();
    }
}
