using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.IdValidator
{
    public interface IIdExistValidator
    {
        bool ValidateIdExist(long id);
    }
}
