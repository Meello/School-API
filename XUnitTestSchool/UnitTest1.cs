using System;
using Xunit;
using FluentAssertions;
using School.Core.Validators.NullOrZero;
using StoneCo.Buy4.School.DataContracts;
using System.Linq;

namespace XUnitTestSchool
{
    public class SchoolTeacherTest
    {
        [Fact]
        public void NullOrZeroTest()
        {
            OperationResponseBase response = new OperationResponseBase();

            NullOrZeroValidator nullOrZero = new NullOrZeroValidator();

            bool test = nullOrZero.Execute(0, response, "Teste");

            test.Should().Be(true);

            Assert.Single(response.Errors);
        }

        /*
        [Theory]
        //Parametrizando os valores
        [InlineData(Values)]
        [InlineData(MoreValues)]
        public void Teste(Parametros)
        {

        }
        */
    }
}
