using Recipes.Shared.Dto;
using Refit;

namespace Recipes.Mobile.Repositories;

public interface IRecipeApi
{
    [Get("/recipe/{recipeId}")]
    Task<ApiResponse<RecipeDetailDto>> GetRecipe(string recipeId);

    [Get("/recipes")]
    Task<ApiResponse<RecipeOverviewItemsDto>> GetRecipes(int pageSize = 7, int pageIndex = 0);
}
