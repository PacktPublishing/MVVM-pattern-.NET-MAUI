namespace Recipes.Client.Core.Features.Favorites;

public interface IFavoritesService
{
    Task<IReadOnlyCollection<string>> LoadFavorites();
    Task<bool> IsFavorite(string id);
    Task Add(string id);
    Task Remove(string id);
}
