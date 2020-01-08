using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSchool.Core.Validators.TeacherParameters
{
    public class ValidateSalaryTestData : TheoryData<decimal?,bool>
    {
        public ValidateSalaryTestData()
        {
            Add(1000, true);
            Add(1000.00m, true);
            Add(10000, true);
            Add(10000.00m, true);
            Add(999.99m, false);
            Add(999.999m, false);
            Add(10000.01m, false);
            Add(10000.001m, false);
            Add(long.MinValue, false);
            Add(long.MinValue, false);
            Add(0, false);
            Add(0.00m, false);
        }
    }
}
