namespace Recipes.Shared.Dto;

public record RecipeIngredientDto(
    string IngredientName,
    double BaseAmount,
    string Measurement,
    int BaseServings);
