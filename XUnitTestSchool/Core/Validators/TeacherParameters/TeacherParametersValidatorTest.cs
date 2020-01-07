using FluentAssertions;
using Moq;
using School.Core.Repositories;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestSchool.Core.Validators.TeacherParameters
{
    public class TeacherParametersValidatorTest
    {
        public const long maxLong = long.MaxValue;
        public const long minLong = long.MinValue;
        public const char minChar = char.MinValue;
        public const char maxChar = char.MaxValue;

        private readonly Mock<ILevelRepository> _levelRepositoryMock;

        private readonly TeacherParametersValidator _validator;

        public TeacherParametersValidatorTest()
        {
            this._levelRepositoryMock = new Mock<ILevelRepository>();

            this._validator = new TeacherParametersValidator(this._levelRepositoryMock.Object);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(0, false)]
        [InlineData(maxLong,true)]
        [InlineData(minLong, false)]
        public void ValidateTeacherId_Should_AddError_When_ReceiveNullOrZero_And_DoNothing_Otherwise(long? input, bool isValid)
        {
            // Arrange
            OperationResponseBase responseBase = new OperationResponseBase();
            int errorCount = isValid ? 0 : 1;

            // Act
            this._validator.ValidateTeacherId(input, responseBase);

            // Assert
            responseBase.Success.Should().Be(isValid);
            responseBase.Errors.Count.Should().Be(errorCount);
        }

        [Theory]
        [InlineData("",false,1)]
        [InlineData(null,false,1)]
        [InlineData("b@&¨@&*%#!&$)*#&*$¨@#&%*)@#&%$(@#¨&%&($(", false, 2)]
        [InlineData("12345678901234567890123456789012", false, 1)]
        [InlineData("q^/", false, 1)]
        [InlineData("123456789012345678901234567890123", false, 2)]
        [InlineData("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", false, 1)]
        [InlineData("qá", true, 0)]
        [InlineData("a", true, 0)]
        [InlineData("abcdefghijklmnopqrstuvwxyzABCDEF", true, 0)]
        public void ValidateName_Should_WorkCorrectly(string input, bool isValid, int errorCount)
        {
            // Arrange
            OperationResponseBase response = new OperationResponseBase();

            // Act
            this._validator.ValidateName(input, response);

            // Assert
            response.Errors.Count.Should().Be(errorCount);
            response.Success.Should().Be(isValid);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(minChar, false)]
        [InlineData(maxChar, false)]
        [InlineData('A', false)]
        [InlineData('Z', false)]
        [InlineData('F', true)]
        [InlineData('M', true)]
        public void IsGenderValid_Should_ReturnTrue_When_FOrM_And_False_Otherwise(char? input, bool isValid)
        {
            // Act
            bool actual = this._validator.IsGenderValid(input);

            // Assert
            actual.Should().Be(isValid);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData('\0', false)]
        [InlineData('A', false)]
        [InlineData('Z', false)]
        [InlineData('F', true)]
        [InlineData('M', true)]
        public void ValidateGender_Should_ReturnTrue_When_FOrM_And_False_Otherwise(char? input, bool isValid)
        {
            // Arrange
            int errorCount = isValid ? 0 : 1;

            OperationResponseBase responseBase = new OperationResponseBase();

            // Act
            this._validator.ValidateGender(input, responseBase);

            // Assert
            responseBase.Success.Should().Be(isValid);
            responseBase.Errors.Count.Should().Be(errorCount);
        }
    }
}

//this._levelRepositoryMock.Setup(x => x.ExistByLevelId(It.IsAny<char>())).Returns(false);