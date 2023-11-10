namespace Recipes.Client.Core.Features.Favorites;

public interface IFavoritesRepository
{
    Task<Result<string[]>> 
        LoadFavorites(string userId);
    Task<Result<Nothing>> Add(string userId, string id);
    Task<Result<Nothing>> Remove(string userId, string id);
}
