namespace Recipes.Client.Core.Features.Recipes;

public class RecipeService : IRecipeService
{
    readonly IRecipeRepository _recipeRepository;

    public Task<Result<RecipeDetail>> LoadRecipe(string id)
        =>  _recipeRepository.LoadRecipe(id);

    public Task<Result<LoadRecipesResponse>> LoadRecipes(
        int pageSize = 7, int page = 0)
        =>  _recipeRepository.LoadRecipes(pageSize, page);

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
}
