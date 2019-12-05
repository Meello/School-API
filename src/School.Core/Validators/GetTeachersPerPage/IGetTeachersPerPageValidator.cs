using StoneCo.Buy4.School.DataContracts.GetTeacherPerPage;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.GetTeachersPerPage
{
    public interface IGetTeachersPerPageValidator
    {
        void NumberOfElementsValiator(int pageNumber, int elementsPerPage, GetTeachersPerPageResponse response);
    }
}
