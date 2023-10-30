using CommunityToolkit.Mvvm.Messaging;
using Recipes.Client.Core.Messages;

namespace Recipes.Client.Core.Favorites;

public class FavoritesService : IFavoritesService
{
    readonly List<string> favorites = new List<string>();

    public Task Add(string id)
    {
        if(!favorites.Contains(id))
        {
            favorites.Add(id);
            WeakReferenceMessenger.Default
                .Send(new FavoriteUpdateMessage(id, true));
        }
        return Task.CompletedTask;
    }

    public Task<bool> IsFavorite(string id)
        => Task.FromResult(favorites.Contains(id));

    public Task<IReadOnlyCollection<string>> LoadFavorites()
        => Task.FromResult<IReadOnlyCollection<string>>(favorites.AsReadOnly());

    public Task Remove(string id)
    {
        if (favorites.Contains(id))
        {
            favorites.Remove(id);
            WeakReferenceMessenger.Default
                .Send(new FavoriteUpdateMessage(id, false));
        }
        return Task.CompletedTask;
    }
}
