namespace Recipes.Shared.Dto;

public record RatingDto(string Id, string RecipeId, double Rating, string UserName, string Review);