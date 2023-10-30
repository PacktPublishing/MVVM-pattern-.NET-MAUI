namespace Recipes.Client.Core.Features.Recipes;

public record LoadRecipesResponse(
    int TotalItems,
    int PageIndex,
    int PageSize,
    IReadOnlyCollection<RecipeOverviewItemDto> Recipes);
