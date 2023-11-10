namespace Recipes.Client.Core.Features.Ratings;

public interface IRatingsService
{
    Task<Result<RatingsSummary>> LoadRatingsSummary(string recipeId);
    Task<Result<IReadOnlyCollection<Rating>>> LoadRatings(string recipeId);
}
