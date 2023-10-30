using Recipes.Client.Core.Features.Recipes;
using Recipes.Shared.Dto;

namespace Recipes.Client.Repositories.Mappers;

internal static class RecipeMapper
{
    internal static LoadRecipesResponse MapRecipesOverview(RecipeOverviewItemsDto result)
    => new LoadRecipesResponse(result.TotalItems, result.PageIndex, result.PageSize,
        result.Recipes.Select(MapRecipesOverviewItem).ToArray());

    internal static RecipeOverviewItem MapRecipesOverviewItem(RecipeOverviewItemDto dto)
        => new RecipeOverviewItem(dto.Id, dto.Title, dto.Image);

    internal static RecipeDetail MapRecipe(RecipeDetailDto result)
    => new(result.Id, result.Name, result.Allergens,
        MapIngredients(result.Ingredients),
        MapInstructions(result.Instructions),
        result.LastUpdated, result.Author, result.Image,
        result.Calories, result.ReadyInMinutes);

    internal static RecipeIngredient[] MapIngredients(
        RecipeIngredientDto[] result)
        => result.Select(r => new RecipeIngredient(
            r.IngredientName, r.BaseAmount, r.Measurement,
            r.BaseServings)).ToArray();

    internal static Instruction[] MapInstructions(
        InstructionDto[] result)
        => result.Select(r => new Instruction(
            r.Text, r.IsNote, r.Index)).ToArray();
}
