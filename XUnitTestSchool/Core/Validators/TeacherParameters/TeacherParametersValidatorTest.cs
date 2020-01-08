using FluentAssertions;
using Moq;
using School.Core.Repositories;
using School.Core.Validators.ValidateTeacherParameters;
using StoneCo.Buy4.School.DataContracts;
using System;
using System.Collections;
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

            this._levelRepositoryMock.Setup(x => x.ListAll()).Returns("SPJ");

            //this._levelRepositoryMock.Setup(x => x.ExistByLevelId(It.IsAny<char>())).Returns(false);

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
        [ClassData(typeof(ValidateNameTestData))]
        public void ValidateName_Should_WorkCorrectly(string input, bool isValid, int errorCount)
        {
            // Arrange
            OperationResponseBase response = new OperationResponseBase();

            // Act
            this._validator.ValidateName(input, response);

            // Assert
            response.Success.Should().Be(isValid);
            response.Errors.Count.Should().Be(errorCount);
        }

        [Theory]
        [ClassData(typeof(ValidateGenderTestData))]
        public void IsGenderValid_Should_ReturnTrue_When_FOrM_And_False_Otherwise(char? input, bool isValid)
        {
            // Act
            bool actual = this._validator.IsGenderValid(input);

            // Assert
            actual.Should().Be(isValid);
        }

        [Theory]
        [ClassData(typeof(ValidateGenderTestData))]
        public void ValidateGender_Should_HaveNoError_When_FOrM_And_AddError_Otherwise(char? input, bool isValid)
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

        [Theory]
        [ClassData(typeof(ValidateLevelTestData))]
        public void ValidateLevel_Should_HaveNoError_When_SOrPOrJ_And_AddError_Otherwise(char? input, bool isValid)
        {
            // Arrange
            int errorCount = isValid ? 0 : 1;

            OperationResponseBase responseBase = new OperationResponseBase();

            // Act
            this._validator.ValidateLevel(input, responseBase);

            // Assert
            responseBase.Success.Should().Be(isValid);
            responseBase.Errors.Count.Should().Be(errorCount);
        }

        [Theory]
        [ClassData(typeof(ValidateSalaryTestData))]
        public void ValidateSalary_Should_HaveNoError_When_Between1000And10000_And_AddError_Otherwise(decimal? input, bool isValid)
        {
            // Arrange
            int errorCount = isValid ? 0 : 1;

            OperationResponseBase responseBase = new OperationResponseBase();

            // Act
            this._validator.ValidateSalary(input, responseBase, "Teste");

            // Assert
            responseBase.Success.Should().Be(isValid);
            responseBase.Errors.Count.Should().Be(errorCount);
        }

        [Theory]
        [ClassData(typeof(ValidateSalaryTestData))]
        public void ValidateAdmitionDate_Should_HaveNoError_When_Between1000And10000_And_AddError_Otherwise(decimal? input, bool isValid)
        {
            // Arrange
            int errorCount = isValid ? 0 : 1;

            OperationResponseBase responseBase = new OperationResponseBase();

            // Act
            this._validator.ValidateSalary(input, responseBase, "Teste");

            // Assert
            responseBase.Success.Should().Be(isValid);
            responseBase.Errors.Count.Should().Be(errorCount);
        }
    }
}