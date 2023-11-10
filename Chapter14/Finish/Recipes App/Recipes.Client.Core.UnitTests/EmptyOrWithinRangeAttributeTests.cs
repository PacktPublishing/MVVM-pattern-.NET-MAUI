using Bogus;
using Recipes.Client.Core.Validation;

namespace Recipes.Client.Core.UnitTests
{
    public class EmptyOrWithinRangeAttributeTests
    {
        const int MinValueStart = 5;
        const int MinValueEnd = 10;
        const int MaxValueStart = 11;
        const int MaxValueEnd = 15;

        readonly EmptyOrWithinRangeAttribute sut;

        public EmptyOrWithinRangeAttributeTests()
        {
            sut = new Faker<EmptyOrWithinRangeAttribute>()
                .RuleFor(r => r.MinLength, f => f.Random.Int(MinValueStart, MinValueEnd))
                .RuleFor(r => r.MaxLength, f => f.Random.Int(MaxValueStart, MaxValueEnd))
                .Generate();
        }

        [Fact]
        public void Value_WithinRange_IsValid()
        {
            //Arrange
            var input = new Faker().Random.String2(
                sut.MinLength, sut.MaxLength);

            //Act
            var isValid = sut.IsValid(input);

            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void Value_TooShort_IsNotValid()
        {
            //Arrange
            var input = new Faker().Random.String2(
                1, MinValueStart - 1);

            //Act
            var isValid = sut.IsValid(input);

            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void Value_TooLong_IsNotValid()
        {
            //Arrange
            var input = new Faker().Random.String2(MaxValueEnd + 1, MaxValueEnd + 10);

            //Act
            var isValid = sut.IsValid(input);

            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void Value_Emtpy_IsValid()
        {
            //Arrange
            var input = string.Empty;

            //Act
            var isValid = sut.IsValid(input);

            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void ValueNull_IsNotValid()
        {
            //Arrange
            string? input = null;

            //Act
            var isValid = sut.IsValid(input);

            //Assert
            Assert.False(isValid);
        }
    }
}