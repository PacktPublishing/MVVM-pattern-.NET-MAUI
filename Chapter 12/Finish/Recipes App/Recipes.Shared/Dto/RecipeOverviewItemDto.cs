namespace Recipes.Shared.Dto;

public record RecipeOverviewItemDto(string Id, string Title, string? Image = null);

public record RecipeOverviewItemsDto(int TotalItems, int PageSize, int PageIndex, RecipeOverviewItemDto[] Recipes);
