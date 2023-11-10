using Localization;
using Recipes.Client.Core;
using Recipes.Client.Core.Features.Recipes;
using static Recipes.Client.Repositories.Mappers.RecipeMapper;

namespace Recipes.Mobile.Repositories;

internal class RecipeApiGateway : ApiGateway, IRecipeRepository
{
    readonly IRecipeApi _api;
    readonly ILocalizationManager _localizationManager;

    public Task<Result<LoadRecipesResponse>> LoadRecipes(int pageSize, int page)
        => InvokeAndMap(_api.GetRecipes(_localizationManager.GetUserCulture().Name, pageSize, page), MapRecipesOverview);

    public Task<Result<RecipeDetail>> LoadRecipe(string id)
        => InvokeAndMap(_api.GetRecipe(id), MapRecipe);

    public RecipeApiGateway(IRecipeApi api, 
        ILocalizationManager localizationManager)
    {
        _api = api;
        _localizationManager = localizationManager;
    }
}
