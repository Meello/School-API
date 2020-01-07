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
        private readonly Mock<ILevelRepository> _levelRepositoryMock;

        private readonly TeacherParametersValidator _validator;

        public TeacherParametersValidatorTest()
        {
            this._levelRepositoryMock = new Mock<ILevelRepository>();

            this._validator = new TeacherParametersValidator(this._levelRepositoryMock.Object);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData('\0', false)]
        [InlineData('A', false)]
        [InlineData('Z', false)]
        [InlineData('F', true)]
        [InlineData('M', true)]
        public void IsGenderValid_Should_Return_True_When_F_Or_M_And_False_Otherwise(char? input, bool isValid)
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
        public void ValidateGender_When_ResponseBaseIsPassed_Should_WorkCorrectly(char? input, bool isValid)
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

        [Fact]
        public void bla()
        {
            // Arrange
            this._levelRepositoryMock.Setup(x => x.ExistByLevelId(It.IsAny<char>())).Returns(false);
        }
    }
}
