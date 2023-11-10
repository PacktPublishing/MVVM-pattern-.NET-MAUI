namespace Recipes.Shared.Dto;

public record RecipeDetailDto(
    string Id,
    string Name,
    string[] Allergens,
    RecipeIngredientDto[] Ingredients,
    InstructionDto[] Instructions,
    DateTime LastUpdated,
    string Author,
    string? Image = null,
    int? Calories = null,
    int? ReadyInMinutes = null);
