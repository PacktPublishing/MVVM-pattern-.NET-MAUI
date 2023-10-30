using AutoBogus;
using Moq;
using Recipes.Client.Core.Features.Favorites;
using Recipes.Client.Core.Features.Ratings;
using Recipes.Client.Core.Features.Recipes;
using Recipes.Client.Core.Navigation;
using Recipes.Client.Core.Services;
using Recipes.Client.Core.ViewModels;

namespace Recipes.Client.Core.UnitTests;
public class RecipeDetailViewModelTests
{
    readonly Mock<IRecipeService> _recipeServiceMock;
    readonly Mock<IFavoritesService> _favoritesServiceMock;
    readonly Mock<IRatingsService> _ratingsServiceMock;
    readonly Mock<INavigationService> _navigationServiceMock;
    readonly Mock<IDialogService> _dialogServiceMock;
    
    readonly RecipeDetailViewModel sut;

    public RecipeDetailViewModelTests()
    {
        _recipeServiceMock = new();
        _favoritesServiceMock = new();
        _ratingsServiceMock = new();
        _navigationServiceMock = new();
        _dialogServiceMock = new();

        _ratingsServiceMock
            .Setup(m => m.LoadRatingsSummary(It.IsAny<string>()))
            .ReturnsAsync(Result<RatingsSummary>
            .Success(AutoFaker.Generate<RatingsSummary>()));

        sut =
            new RecipeDetailViewModel(_recipeServiceMock.Object,
            _favoritesServiceMock.Object, _ratingsServiceMock.Object,
            _navigationServiceMock.Object, _dialogServiceMock.Object);
    }

    [Fact]
    public async Task OnNavigatedTo_Should_Load_Recipe()
    {
        //Arrange
        var recipeId = AutoFaker.Generate<string>();

        var parameters = new Dictionary<string, object> { 
            { "id", recipeId } 
        };

        _recipeServiceMock
            .Setup(m => m.LoadRecipe(It.IsAny<string>()))
            .ReturnsAsync(Result<RecipeDetail>
            .Success(AutoFaker.Generate<RecipeDetail>()));

        //Act
        await sut.OnNavigatedTo(parameters);

        //Assert
        _recipeServiceMock.Verify(m => m.LoadRecipe(recipeId), Times.Once);
    }

    [Fact]
    public async Task OnNavigatedTo_Should_Map_RecipeDetail()
    {
        //Arrange
        var recipeDetail = AutoFaker.Generate<RecipeDetail>();

        var parameters = new Dictionary<string, object> { 
            { "id", AutoFaker.Generate<string>() } 
        };

        _recipeServiceMock
            .Setup(m => m.LoadRecipe(It.IsAny<string>()))
            .ReturnsAsync(Result<RecipeDetail>
            .Success(recipeDetail));

        //Act
        await sut.OnNavigatedTo(parameters);

        //Assert
        Assert.Equal(recipeDetail.Name, sut.Title);
        Assert.Equal(recipeDetail.Author, sut.Author);
    }

    [Fact]
    public async Task FailedLoad_Should_ShowDialog()
    {
        //Arrange
        var parameters = new Dictionary<string, object> {
            { "id", AutoFaker.Generate<string>() }
        };

        _recipeServiceMock
            .Setup(m => m.LoadRecipe(It.IsAny<string>()))
            .ReturnsAsync(Result<RecipeDetail>
            .Fail(AutoFaker.Generate<string>()));

        _dialogServiceMock
            .Setup(m => m.AskYesNo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(false);

        //Act
        await sut.OnNavigatedTo(parameters);

        //Assert
        _dialogServiceMock.Verify(m => m.AskYesNo(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        _navigationServiceMock.Verify(m => m.GoBack(), Times.Once);
    }
}