using Recipes.Client.Core.Features.Ratings;
using Recipes.Shared.Dto;

namespace Recipes.Client.Repositories.Mappers;

internal static class RatingsMapper
{
    internal static IReadOnlyCollection<Rating> MapRatings(RatingDto[] dtos)
    => dtos.Select(r => new Rating(r.Id, r.RecipeId,
        r.Rating,
        r.UserName,
        r.Review))
    .ToArray();

    internal static RatingsSummary MapRatingSummary(RatingsSummaryDto dto)
        => new RatingsSummary(dto.TotalReviews, dto.MaxRating, dto.AverageRating);
}
