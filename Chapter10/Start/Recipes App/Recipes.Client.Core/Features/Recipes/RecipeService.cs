namespace Recipes.Client.Core.Features.Recipes;

public class RecipeService : IRecipeService
{
    public Task<Result<RecipeDetail>> LoadRecipe(string id)
        => throw new NotImplementedException();

    public Task<Result<LoadRecipesResponse>> LoadRecipes(
        int pageSize = 7, int page = 0)
        => throw new NotImplementedException();
}
