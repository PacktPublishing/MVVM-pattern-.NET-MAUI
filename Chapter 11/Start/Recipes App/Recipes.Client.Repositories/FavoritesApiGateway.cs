using Recipes.Client.Core;
using Recipes.Client.Core.Features.Favorites;
using Recipes.Shared.Dto;

namespace Recipes.Mobile.Repositories;

internal class FavoritesApiGateway : ApiGateway, IFavoritesRepository
{
    readonly IFavoritesApi _api;

    public Task<Result<Nothing>> Add(string userId, string id)
        => InvokeAndMap(_api.AddFavorite(userId, new FavoriteDto(id)));

    public Task<Result<string[]>> LoadFavorites(string userId)
        => InvokeAndMap(_api.GetFavorites(userId));

    public Task<Result<Nothing>> Remove(string userId, string recipeId)
        => InvokeAndMap(_api.DeleteFavorite(userId, recipeId));

    public FavoritesApiGateway(IFavoritesApi api)
    {
        _api = api;
    }
}
