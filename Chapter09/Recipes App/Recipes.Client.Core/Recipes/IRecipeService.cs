namespace Recipes.Client.Core.Recipes;

public interface IRecipeService
{
    Task<LoadRecipesResponse> LoadRecipes(int pageSize = 7, int page = 0);
    Task<RecipeDetailDto?> LoadRecipe(string id);
}
