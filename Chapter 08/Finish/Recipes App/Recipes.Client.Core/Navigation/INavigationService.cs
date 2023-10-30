using Recipes.Client.Core.Features.Recipes;

namespace Recipes.Client.Core.Navigation;

public interface INavigationService
{
    Task GoToOverview();
    Task GoToRecipeDetail(string recipeId);
    Task GoToRecipeRatingDetail(RecipeDetailDto recipe);
    Task GoBack();
    Task GoBackAndReturn(Dictionary<string, object> parameters);
    Task GoToChooseLanguage(string currentLanguage);
}
