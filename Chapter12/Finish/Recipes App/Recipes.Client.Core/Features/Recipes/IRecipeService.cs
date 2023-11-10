namespace Recipes.Client.Core.Features.Recipes;

public interface IRecipeService
{
    Task<Result<LoadRecipesResponse>> LoadRecipes(int pageSize = 7, int page = 0);
    Task<Result<RecipeDetail>> LoadRecipe(string id);
}
