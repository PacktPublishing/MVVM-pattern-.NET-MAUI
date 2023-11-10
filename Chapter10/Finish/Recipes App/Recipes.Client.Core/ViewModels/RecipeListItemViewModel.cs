using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Recipes.Client.Core.Messages;

namespace Recipes.Client.Core.ViewModels;

public class RecipeListItemViewModel : ObservableObject, IRecipient<FavoriteUpdateMessage>
{
    public string Id { get; }
    public string? Image { get; }
    public string Title { get; }

    bool _isFavorite;
    public bool IsFavorite 
    { 
        get => _isFavorite; 
        private set => SetProperty(ref _isFavorite, value);
    }

    public RecipeListItemViewModel(string id, string title, bool isFavorite, string? image = null)
    {
        Id = id;
        Title = title;
        Image = image;
        IsFavorite = isFavorite;

        WeakReferenceMessenger.Default.Register(this);
    }

    void IRecipient<FavoriteUpdateMessage>
        .Receive(FavoriteUpdateMessage message)
    {
        if (message.RecipeId == Id)
        {
            IsFavorite = message.IsFavorite;
        }
    }
}