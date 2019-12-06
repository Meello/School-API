using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.DataBaseValidator
{
    public interface IDataBaseValidator
    {
        bool ValidateIdExist(long id);

        long NumberOfElements();
    }
}
