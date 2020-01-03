using System;
using School.Core.Validators.NullOrZero;
using StoneCo.Buy4.School.DataContracts;
using Xunit;

namespace Test1
{
    public class SchoolTeacherTest
    {
        private readonly INullOrZeroValidator _nullOrZeroValidator;

        public SchoolTeacherTest(
            INullOrZeroValidator nullOrZeroValidator)
        {
            this._nullOrZeroValidator = nullOrZeroValidator;
        }

        [Fact]
        public void NullOrZeroTest()
        {
            OperationResponseBase response = new OperationResponseBase();

            bool test = this._nullOrZeroValidator.Execute(0, response, "Teste");

            Assert.True(test);

            Assert.Single(response.Errors);
        }
    }
}
