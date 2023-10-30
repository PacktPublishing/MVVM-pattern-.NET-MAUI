using CommunityToolkit.Mvvm.Messaging;
using Recipes.Client.Core.Messages;

namespace Recipes.Client.Core.Features.Favorites;

public class FavoritesService : IFavoritesService
{
    readonly IFavoritesRepository _favoritesRepository;
    List<string> favorites = null;

    public async Task<Result<Nothing>> Add(string id)
    {
        var result = await _favoritesRepository
            .Add(GetCurrentUserId(), id);

        if (result.IsSuccess)
        {
            if (favorites is not null
                && !favorites.Contains(id))
                favorites.Add(id);

            WeakReferenceMessenger.Default
                .Send(
                new FavoriteUpdateMessage(id, true));
        }
        return result;
    }

    public async Task<Result<Nothing>> Remove(string id)
    {
        var result = await _favoritesRepository
            .Remove(GetCurrentUserId(), id);

        if (result.IsSuccess)
        {

            if (favorites is not null
                && favorites.Contains(id))
                favorites.Remove(id);

            WeakReferenceMessenger.Default
                .Send(
                new FavoriteUpdateMessage(id, false));
        }

        return result;
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
        if (favorites is null)
        {
            var loadResult = await _favoritesRepository.LoadFavorites(GetCurrentUserId());
            if (loadResult.IsSuccess)
            {
                favorites = loadResult.Data.ToList();
            }
        }
    }

    private string GetCurrentUserId()
        => "3"; //Dummy implementation, could be retrieved via injected 

    public FavoritesService(IFavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }
}
