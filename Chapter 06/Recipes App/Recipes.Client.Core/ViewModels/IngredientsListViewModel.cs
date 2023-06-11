using CommunityToolkit.Mvvm.ComponentModel;

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
                Ingredients.ForEach(i => i.UpdateServings(value));
            }
        }
    }

    public IngredientsListViewModel()
    {
        Ingredients = new()
            {
                new (new("Olive oil"), .5, "Cup"),
                new (new("Garlic (gloves)"), 4),
                new (new("Baguette"), 1),
                new (new("Lemon Juice"), .25, "Cup"),
                new (new("Parmesan cheese (grated)"), 4, "Ounce"),
                new (new("Anchovies"), 1),
                new (new("Egg"), 2),
                new (new("Black pepper"), .25, "Teaspoon"),
                new (new("Salt"), .5,  "Teaspoon"),
                new (new("Romaine lettuce"), 4)
            };
    }

    public List<RecipeIngredientViewModel> Ingredients
    {
        get;
    }
}
