using AutoBogus;
using CommunityToolkit.Mvvm.Messaging;
using Recipes.Client.Core.Messages;
using Recipes.Client.Core.ViewModels;

namespace Recipes.Client.Core.UnitTests;

public class RecipeListItemViewModelTests
{
    [Theory]
    [InlineData("id1", "title1", false, "image1")]
    [InlineData("id2", "title2", true, "image2")]
    [InlineData("foo", ",bar", true, null)]
    [InlineData(null, null, false, null)]
    public void ViewModel_Initialized_PropertiesSetCorrectly(string id, string title, bool isFavorite, string image)
    {
        //Arrange, Act
        var sut = new RecipeListItemViewModel(id, title, isFavorite, image);

        //Assert
        Assert.Equal(id, sut.Id);
        Assert.Equal(title, sut.Title);
        Assert.Equal(isFavorite, sut.IsFavorite);
        Assert.Equal(image, sut.Image);
    }

    [Fact]
    public void VM_Initialized_SubscribedToFavoriteUpdateMessage()
    {
        //Arrange, Act
        var sut = AutoFaker.Generate<RecipeListItemViewModel>();

        //Assert
        Assert.True(WeakReferenceMessenger.Default.IsRegistered<FavoriteUpdateMessage>(sut));
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void 
        FavoriteUpdateMsgRecieved_SameId_FavoriteUpdated(
        bool originalValue, bool updateToValue)
    {
        //Arrange
        var id = AutoFaker.Generate<string>();
        var sut = new RecipeListItemViewModel(id,
            AutoFaker.Generate<string>(), 
            originalValue,
           AutoFaker.Generate<string>());

        //Act
        WeakReferenceMessenger.Default.Send(new FavoriteUpdateMessage(id, updateToValue));

        //Assert
        Assert.Equal(updateToValue, sut.IsFavorite);
    }

    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void FavoriteUpdateMsgRecieved_DifferentId_FavoriteNotUpdated(bool originalValue, bool updateToValue)
    {
        //Arrange
        var sut = new RecipeListItemViewModel("someid", "title", originalValue, "image");

        //Act
        WeakReferenceMessenger.Default.Send(new FavoriteUpdateMessage("otherid", updateToValue));

        //Assert
        Assert.Equal(originalValue, sut.IsFavorite);
    }
}
