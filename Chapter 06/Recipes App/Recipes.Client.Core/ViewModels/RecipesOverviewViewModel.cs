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

    public IEnumerable<IGrouping<string, RecipeListItemViewModel>> GroupedRecipes { get; set; }
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
        Recipes = new ObservableCollection<RecipeListItemViewModel>(items);

        //GroupedRecipes = Recipes.GroupBy(r => r.Title.Substring(0, 1)).ToList();
        TryLoadMoreItemsCommand = new AsyncRelayCommand(TryLoadMoreItems);
        NavigateToSelectedDetailCommand = new AsyncRelayCommand(NavigateToSelectedDetail);
        //RefreshListCommand = new AsyncRelayCommand(RefreshList);
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

    public AsyncRelayCommand RefreshListCommand { get; }
    

    private async Task RefreshList()
    {
        Recipes.Clear();
        foreach (var item in items)
        {
            Recipes.Add(item);
        }
    }
    private bool isListLoading;

    public bool IsListLoading
    {
        get => isListLoading;
        set => SetProperty(ref isListLoading, value);
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
