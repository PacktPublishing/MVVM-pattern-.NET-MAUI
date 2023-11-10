using Recipes.Client.Core;
using Recipes.Client.Core.Features.Ratings;
using static Recipes.Client.Repositories.Mappers.RatingsMapper;

namespace Recipes.Mobile.Repositories;

internal class RatingsApiGateway : ApiGateway, IRatingsRepository
{
    readonly IRatingsApi _api;

    public Task<Result<IReadOnlyCollection<Rating>>>
        GetRatings(string recipeId)
        => InvokeAndMap(
            _api.GetRatings(recipeId), MapRatings);

    public Task<Result<RatingsSummary>>
        GetRatingsSummary(string recipeId)
        => InvokeAndMap(_api.GetRatingsSummary(recipeId),
            MapRatingSummary);

    public RatingsApiGateway(IRatingsApi api)
    {
        _api = api;
    }
}
