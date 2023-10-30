namespace Recipes.Client.Core.Features.Recipes;

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

public record RecipeIngredientDto(
    string IngredientName,
    double BaseAmount,
    string Measurement,
    int BaseServings);

public record InstructionDto(string Text, bool IsNote, int? Index);