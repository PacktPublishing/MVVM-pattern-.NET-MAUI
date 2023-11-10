using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Recipes.Client.Core.Features.Recipes;
using Recipes.Client.Core.Messages;

namespace Recipes.Client.Core.ViewModels;

public class IngredientsListViewModel : ObservableObject
{
    private int _numberOfServings = 4;
    public int NumberOfServings
    {
        get => _numberOfServings;
        set
        {
            if (SetProperty(ref _numberOfServings, value))
            {
                WeakReferenceMessenger.Default.Send(
                    new ServingsChangedMessage(value));
            }
        }
    }

    public IngredientsListViewModel(IReadOnlyList<RecipeIngredientDto> ingredients)
    {
        Ingredients = ingredients.Select(i =>
            new RecipeIngredientViewModel(
                i.IngredientName,
                i.BaseAmount,
                i.Measurement,
                i.BaseServings))
            .ToList();
    }

    public List<RecipeIngredientViewModel> Ingredients
    {
        get;
    }
}
