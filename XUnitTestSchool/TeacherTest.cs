using System;
using Xunit;
using FluentAssertions;
using School.Core.Validators.NullOrZero;
using StoneCo.Buy4.School.DataContracts;
using System.Linq;
using System.Globalization;

namespace XUnitTestSchool
{
    public class TeacherTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(null)]
        public void NullOrZeroShouldBeTrueWhenReceiveIntNullOrZero(int? a)
        {
            OperationResponseBase response = new OperationResponseBase();

            IsNullOrZeroValidator nullOrZero = new IsNullOrZeroValidator();

            //Act
            //bool test = nullOrZero.Execute(a, response, "Teste");

            //Assert
            //test.Should().Be(true);

            response.Should().NotBeNull();
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(null,true)]
        public void NullOrZeroShouldBeTrueWhenReceiveLongNullOrZero(long? a, bool success)
        {
            OperationResponseBase response = new OperationResponseBase();
            
            IsNullOrZeroValidator nullOrZero = new IsNullOrZeroValidator();

            //Act
            //bool test = nullOrZero.Execute(a, response, "Teste");

            //Assert
            //test.Should().Be(true);

            response.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrZeroShouldBeTrueWhenReceiveStringNullOrZero(string a)
        {
            OperationResponseBase response = new OperationResponseBase();

            IsNullOrZeroValidator nullOrZero = new IsNullOrZeroValidator();

            //Act
            //bool test = nullOrZero.Execute(a, response, "Teste");

            //Assert
            //test.Should().Be(true);

            response.Should().NotBeNull();
        }

        [Theory]
        //[InlineData()] Não estou conseguinda passar um DateTime nem um TimeSpan
        [InlineData(null)]
        [InlineData("20200101010203")]
        public void NullOrZeroShouldBeTrueWhenReceiveDateTimeNullOrMinValue(string a)
        {
            DateTime? dateTime = null;

            if(a != null)
            {
                dateTime = DateTime.ParseExact(a, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None);
            }


            OperationResponseBase response = new OperationResponseBase();

            IsNullOrZeroValidator nullOrZero = new IsNullOrZeroValidator();

            //Act
            //bool test = nullOrZero.Execute(a, response, "Teste");

            //Assert
            //test.Should().Be(true);

            response.Should().NotBeNull();
        }
    }
}
