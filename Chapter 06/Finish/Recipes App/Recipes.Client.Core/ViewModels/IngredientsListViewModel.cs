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
                new ("Olive oil", .5, "Cup"),
                new ("Garlic (gloves)", 4),
                new ("Baguette", 1),
                new ("Lemon Juice", .25, "Cup"),
                new ("Parmesan cheese (grated)", 4, "Ounce"),
                new ("Anchovies", 1),
                new ("Egg", 2),
                new ("Black pepper", .25, "Teaspoon"),
                new ("Salt", .5,  "Teaspoon"),
                new ("Romaine lettuce", 4)
            };
    }

    public List<RecipeIngredientViewModel> Ingredients
    {
        get;
    }
}
