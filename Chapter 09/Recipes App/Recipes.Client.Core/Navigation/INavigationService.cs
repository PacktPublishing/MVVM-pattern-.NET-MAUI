using Recipes.Client.Core.Recipes;

namespace Recipes.Client.Core.Navigation;

public interface INavigationService
{
    Task GoToOverview();
    Task GoToRecipeDetail(string recipeId);
    Task GoToRecipeRatingDetail(RecipeDetailDto recipe);
    Task GoToAddRating(RecipeDetailDto recipe);
    Task GoBack();
}
