namespace Recipes.Client.Core.Features.Favorites;

public class FavoritesService : IFavoritesService
{
    readonly List<string> favorites = new List<string>();

    public Task Add(string id)
    {
        if (!favorites.Contains(id))
        {
            favorites.Add(id);
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
        }
        return Task.CompletedTask;
    }
}
