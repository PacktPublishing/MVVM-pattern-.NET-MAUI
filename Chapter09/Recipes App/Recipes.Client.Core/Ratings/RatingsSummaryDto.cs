namespace Recipes.Client.Core.Ratings;

public record RatingsSummaryDto(int TotalReviews, double MaxRating, double? AverageRating);

public record RatingDto(string Id, string RecipeId, double Rating, string UserName, string Review);