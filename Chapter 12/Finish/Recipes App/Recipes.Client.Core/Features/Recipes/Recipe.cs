namespace Recipes.Client.Core.Features.Recipes;

public record RecipeDetail(
    string Id,
    string Name,
    string[] Allergens,
    RecipeIngredient[] Ingredients,
    Instruction[] Instructions,
    DateTime LastUpdated,
    string Author,
    string? Image = null,
    int? Calories = null,
    int? ReadyInMinutes = null);

public record RecipeIngredient(
    string IngredientName,
    double BaseAmount,
    string Measurement,
    int BaseServings);

public record Instruction(string Text, bool IsNote, int? Index);

public record RecipeOverviewItem(string Id, string Title, string? Image = null);

public record LoadRecipesResponse(
    int TotalItems,
    int PageIndex,
    int PageSize,
    IReadOnlyCollection<RecipeOverviewItem> Recipes);