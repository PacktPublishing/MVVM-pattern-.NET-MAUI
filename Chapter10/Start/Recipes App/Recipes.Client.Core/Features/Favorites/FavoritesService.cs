using CommunityToolkit.Mvvm.Messaging;
using Recipes.Client.Core.Messages;

namespace Recipes.Client.Core.Features.Favorites;

public class FavoritesService : IFavoritesService
{
    List<string> favorites = null;

    public async Task<Result<Nothing>> Add(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Nothing>> Remove(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsFavorite(string id)
    {
        await LoadList();
        return favorites is not null && favorites.Contains(id);
    }

    public async Task<IReadOnlyCollection<string>?> LoadFavorites()
    {
        await LoadList();
        return favorites?.AsReadOnly();
    }

    private async ValueTask LoadList()
    {
        throw new NotImplementedException();
    }

    private string GetCurrentUserId()
        => "3"; //Dummy implementation, could be retrieved via injected 
}
