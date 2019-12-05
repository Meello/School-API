using StoneCo.Buy4.School.DataContracts.GetTeacherPerPage;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Operations
{
    public interface IGetTeachersPerPage
    {
        GetTeachersPerPageResponse ProcessOperation(GetTeachersPerPageRequest request);
    }
}
