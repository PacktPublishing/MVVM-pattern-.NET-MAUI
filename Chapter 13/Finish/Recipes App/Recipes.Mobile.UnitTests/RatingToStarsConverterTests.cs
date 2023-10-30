using Recipes.Mobile.Converters;

namespace Recipes.Mobile.UnitTests;

public class RatingToStarsConverterTests
{
    [Theory]
    [InlineData("foo", "")]
    [InlineData(-1d, "")]
    [InlineData(6d, "")]
    [InlineData(1d, "\ue838")]
    [InlineData(2d, "\ue838\ue838")]
    [InlineData(2.2d, "\ue838\ue838")]
    [InlineData(2.5d, "\ue838\ue838\ue839")]
    [InlineData(2.9d, "\ue838\ue838\ue839")]
    public void Convert_Should_Return_ExpectedOutput(object input, string expectedOutput)
    {
        //Arrante
        var sut = new RatingToStarsConverter();

        //Act
        var result = sut.Convert(input,
            null, null, null);

        //Assert
        Assert.Equal(expectedOutput, result);
    }
}