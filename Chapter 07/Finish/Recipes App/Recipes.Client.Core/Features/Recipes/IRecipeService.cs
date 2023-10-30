namespace Recipes.Client.Core.Features.Recipes;

public interface IRecipeService
{
    Task<LoadRecipesResponse> LoadRecipes(int pageSize = 7, int page = 0);
    Task<RecipeDetailDto?> LoadRecipe(string id);
}
