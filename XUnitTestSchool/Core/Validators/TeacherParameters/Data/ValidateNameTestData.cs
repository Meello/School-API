using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSchool.Core.Validators.TeacherParameters
{
    public class ValidateNameTestData : TheoryData<string,bool,int>
    {
        public ValidateNameTestData()
        {
            Add("", false, 1);
            Add(null, false, 1);
            Add("b@&¨@&*%#!&$)*#&*$¨@#&%*)@#&%$(@#¨&%&($(", false, 2);
            Add("12345678901234567890123456789012", false, 1);
            Add("q^/", false, 1);
            Add("123456789012345678901234567890123", false, 2);
            Add("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", false, 1);
            Add("qá", true, 0);
            Add("a", true, 0);
            Add("a b c", true, 0);
            Add("abcdefghijklmnopqrstuvwxyzABCDEF", true, 0);
            Add("Bruno Mello", true, 0);
            Add("Cíntia Silveira", true, 0);
        }
    }
}
