namespace Recipes.Client.Core.Features.Ratings;

public class RatingsService : IRatingsService
{
    public Task<Result<RatingsSummary>> LoadRatingsSummary(string recipeId)
        => throw new NotImplementedException();
    public Task<Result<IReadOnlyCollection<Rating>>> LoadRatings(string recipeId)
        => throw new NotImplementedException();
}
