using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.ValidateTeacherObjects.ValidateIfIsNull
{
    public class ValidateNameNull : IValidateNameNull
    {
        public bool ValidateIfNameIsNull(string str)
        {
            if(str == null)
            {
                return true;
            }

            return false;
        }
    }
}
