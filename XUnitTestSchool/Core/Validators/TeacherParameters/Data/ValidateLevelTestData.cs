using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSchool.Core.Validators.TeacherParameters
{
    public class ValidateLevelTestData : TheoryData<char?,bool>
    {
        public ValidateLevelTestData()
        {
            Add('S',true);
            Add('P', true);
            Add('J', true);
            Add('A', false);
            Add('Z', false);
            Add(' ', false);
            Add(null, false);
            Add(char.MinValue, false);
            Add(char.MaxValue, false);
        }
    }
}
