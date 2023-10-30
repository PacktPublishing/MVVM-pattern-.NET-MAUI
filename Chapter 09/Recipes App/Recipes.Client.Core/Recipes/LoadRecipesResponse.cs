namespace Recipes.Client.Core.Recipes;

public record LoadRecipesResponse(
    int TotalItems, 
    int PageIndex, 
    int PageSize, 
    IReadOnlyCollection<RecipeOverviewItemDto> Recipes);
