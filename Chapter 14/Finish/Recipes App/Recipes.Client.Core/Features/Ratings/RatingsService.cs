namespace Recipes.Client.Core.Features.Ratings;

public class RatingsService : IRatingsService
{
    readonly IRatingsRepository _ratingsRepository;

    public Task<Result<RatingsSummary>> LoadRatingsSummary(string recipeId)
        => _ratingsRepository.GetRatingsSummary(recipeId);
    public Task<Result<IReadOnlyCollection<Rating>>> LoadRatings(string recipeId)
        => _ratingsRepository.GetRatings(recipeId);

    public RatingsService(IRatingsRepository ratingsRepository)
    {
        _ratingsRepository = ratingsRepository;
    }
}
