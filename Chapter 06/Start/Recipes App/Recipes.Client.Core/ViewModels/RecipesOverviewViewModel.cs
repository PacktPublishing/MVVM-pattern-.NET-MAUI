using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Recipes.Client.Core.ViewModels;

public class RecipesOverviewViewModel : ObservableObject
{
    List<RecipeListItemViewModel> items = new()
            {
                new ("1", "Classic Caesar Salad",true, "caesarsalad"),
                new ("2", "Belgian Waffles",true, "waffle"),
                new ("3", "Chicken Parmesan",true),
                new ("4", "Moules-Frites",true, "moules"),
                new ("5", "Spaghetti Carbonara",true, "carbonara"),
                new ("6", "Chicken Stir-Fry",true, "stirfry"),
                new ("7", "Pad Thai",true)
            };

    public ObservableCollection<RecipeListItemViewModel> Recipes { get; }

    public int TotalNumberOfRecipes { get; } = 404;

    public RecipesOverviewViewModel()
    {
        Recipes = new ObservableCollection<RecipeListItemViewModel>(items);
    }
}
