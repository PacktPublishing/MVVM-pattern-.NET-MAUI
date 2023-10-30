using CommunityToolkit.Mvvm.ComponentModel;
using Recipes.Client.Core.Features.Recipes;

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
                Ingredients
                .ForEach(i => i.UpdateServings(value));
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
