using Recipes.Shared.Dto;
using Refit;

namespace Recipes.Mobile.Repositories;

public interface IRatingsApi
{
    [Get("/recipe/{recipeId}/ratings")]
    Task<ApiResponse<RatingDto[]>> GetRatings(string recipeId);

    [Get("/recipe/{recipeId}/ratingssummary")]
    Task<ApiResponse<RatingsSummaryDto>> GetRatingsSummary(string recipeId);
}
