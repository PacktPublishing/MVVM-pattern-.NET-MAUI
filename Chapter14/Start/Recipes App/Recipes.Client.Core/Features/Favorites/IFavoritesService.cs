namespace Recipes.Client.Core.Features.Favorites;

public interface IFavoritesService
{
    Task<IReadOnlyCollection<string>?> LoadFavorites();
    Task<bool> IsFavorite(string id);
    Task<Result<Nothing>> Add(string id);
    Task<Result<Nothing>> Remove(string id);
}
