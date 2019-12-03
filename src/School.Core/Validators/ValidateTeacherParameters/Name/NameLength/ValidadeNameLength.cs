using System;
using System.Collections.Generic;
using System.Text;

namespace School.Core.Validators.ValidateTeacherParameters.Name.NameLength
{
    public class ValidadeNameLength : IValidadeNameLength
    {
        public bool ValidadeNameLength32(string str)
        {
            if(str.Length > 32)
            {
                return true;
            }

            return false;
        }
    }
}
