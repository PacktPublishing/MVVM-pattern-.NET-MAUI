using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Recipes.Client.Core.ViewModels;

public class RecipesOverviewViewModel : ObservableObject
{
    List<RecipeListItemViewModel> items = new List<RecipeListItemViewModel>()
            {
                new ("1", "Classic Caesar Salad", false, "caesarsalad", 3.6),
                new ("2", "Belgian Waffles", true, "waffle", 4),
                new ("3", "Chicken Parmesan", true, avgRating: 3.9),
                new ("4", "Moules-Frites", true, "moules", 2.6),
                new ("5", "Spaghetti Carbonara", false, "carbonara", 3),
                new ("6", "Chicken Stir-Fry", false, "stirfry", 1),
                new ("7", "Pad Thai", false)
            };

    public IEnumerable<IGrouping<string, RecipeListItemViewModel>> GroupedRecipes { get; set; }
    public ObservableCollection<RecipeListItemViewModel> Recipes { get; set; }
    public RecipesOverviewViewModel()
    {
        Recipes = new ObservableCollection<RecipeListItemViewModel>(items);

        GroupedRecipes = Recipes.GroupBy(r => r.Title.Substring(0, 1)).ToList();
        TryLoadMoreItemsCommand = new AsyncRelayCommand(TryLoadMoreItems);
        RefreshListCommand = new AsyncRelayCommand(RefreshList);
    }

    private async Task RefreshList()
    {
        Recipes.Clear();
        foreach (var item in items)
        {
            Recipes.Add(item);
        }
    }

    public AsyncRelayCommand TryLoadMoreItemsCommand { get; }
    public AsyncRelayCommand RefreshListCommand { get; }

    private bool isListLoading;

    public bool IsListLoading
    {
        get => isListLoading;
        set => SetProperty(ref isListLoading, value);
    }


    private async Task TryLoadMoreItems()
    {
        IsListLoading = true;
        System.Diagnostics.Debug.WriteLine("Loading more items...");
        foreach (var item in items)
        {
            Recipes.Add(item);
        }
        IsListLoading = false;
    }
}
