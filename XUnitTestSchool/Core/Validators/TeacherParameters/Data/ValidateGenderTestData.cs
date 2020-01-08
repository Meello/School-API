using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSchool.Core.Validators.TeacherParameters
{
    public class ValidateGenderTestData : TheoryData<char?,bool>
    {
        public ValidateGenderTestData()
        {
            Add(null, false);
            Add(char.MinValue, false);
            Add(char.MaxValue, false);
            Add(' ', false);
            Add('A', false);
            Add('Z', false);
            Add('F', true);
            Add('M', true);
        }
    }
}
