namespace Recipes.Client.Core.Features.Ratings;

public interface IRatingsRepository
{
    Task<Result<IReadOnlyCollection<Rating>>> GetRatings(string recipeId);
    Task<Result<RatingsSummary>> GetRatingsSummary(string recipeId);
}