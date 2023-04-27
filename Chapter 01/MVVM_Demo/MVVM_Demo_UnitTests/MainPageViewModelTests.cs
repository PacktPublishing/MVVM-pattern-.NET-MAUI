using Moq;
using MVVM_Demo;

namespace MVVM_Demo_UnitTests;

public class MainPageViewModelTests
{
    private Mock<IQuoteService> quoteServiceMock;

    public MainPageViewModelTests()
    {
        quoteServiceMock = new Mock<IQuoteService>();
        quoteServiceMock.Setup(m => m.GetQuote()).ReturnsAsync(string.Empty);
    }

    [Fact]
    public void ButtonShouldBeVisible()
    {
        var sut = new MainPageViewModel(quoteServiceMock.Object);
        Assert.True(sut.IsButtonVisible);
    }

    [Fact]
    public void LabelShouldNotBeVisible()
    {
        var sut = new MainPageViewModel(quoteServiceMock.Object);
        Assert.False(sut.IsLabelVisible);
    }

    [Fact]
    public void GetQuoteCommand_ShoudCallGetQuote()
    {
        var sut = new MainPageViewModel(quoteServiceMock.Object);

        sut.GetQuoteCommand.Execute(null);

        quoteServiceMock.Verify(m => m.GetQuote(), Times.Once());
    }

    [Fact]
    public void GetQuoteCommand_ShoudSetButtonInvisible()
    {
        var sut = new MainPageViewModel(quoteServiceMock.Object);

        sut.GetQuoteCommand.Execute(null);

        Assert.False(sut.IsButtonVisible);
    }

    [Fact]
    public void GetQuoteCommand_GotQuote_ShowQuote()
    {
        var quote = "My quote of the day";
        quoteServiceMock.Setup(m => m.GetQuote()).ReturnsAsync(quote);

        var sut = new MainPageViewModel(quoteServiceMock.Object);

        sut.GetQuoteCommand.Execute(null);

        Assert.True(sut.IsLabelVisible);
        Assert.Equal(quote, sut.QuoteOfTheDay);
    }

    [Fact]
    public void GetQuoteCommand_ServiceThrows_ShouldShowButton()
    {
        quoteServiceMock.Setup(m => m.GetQuote()).ThrowsAsync(new Exception());

        var sut = new MainPageViewModel(quoteServiceMock.Object);

        sut.GetQuoteCommand.Execute(null);

        Assert.True(sut.IsButtonVisible);
    }
}