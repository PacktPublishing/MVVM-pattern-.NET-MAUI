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

    RecipeListItemViewModel? _selectedRecipe;
    public RecipeListItemViewModel? SelectedRecipe
    {
        get => _selectedRecipe;
        set => SetProperty(ref _selectedRecipe, value);
    }

    public int TotalNumberOfRecipes { get; } = 404;

    public AsyncRelayCommand TryLoadMoreItemsCommand { get; }
    public AsyncRelayCommand NavigateToSelectedDetailCommand { get; }

    public RecipesOverviewViewModel()
    {
        Recipes = new ObservableCollection<RecipeListItemViewModel>(items); ;
        TryLoadMoreItemsCommand = new AsyncRelayCommand(TryLoadMoreItems);
        NavigateToSelectedDetailCommand = new AsyncRelayCommand(NavigateToSelectedDetail);
    }

    private Task NavigateToSelectedDetail()
    {
        if (SelectedRecipe is not null)
        {
            //ToDo navigate to selected item
            SelectedRecipe = null;
        }
        return Task.CompletedTask;
    }

    private async Task TryLoadMoreItems()
    {
        //Dummy implementation
        if (Recipes.Count < TotalNumberOfRecipes)
        {
            await Task.Delay(250);
            foreach (var item in items)
            {
                Recipes.Add(item);
            }
        }
    }
}
