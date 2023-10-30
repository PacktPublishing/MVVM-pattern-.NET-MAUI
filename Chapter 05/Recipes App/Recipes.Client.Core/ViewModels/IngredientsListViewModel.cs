using CommunityToolkit.Mvvm.ComponentModel;

namespace Recipes.Client.Core.ViewModels;

public class IngredientsListViewModel : ObservableObject
{
    private int _numberOfServings = 4;
    public int NumberOfServings
    {
        get => _numberOfServings;
        set => SetProperty(ref _numberOfServings, value);
    }
    //ToDo: add list of Ingredients
}