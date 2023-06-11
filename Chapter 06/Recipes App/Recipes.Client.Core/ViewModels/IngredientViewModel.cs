namespace Recipes.Client.Core.ViewModels;

public class IngredientViewModel
{
    public string Name { get; }

    public IngredientViewModel(string name)
        => Name = name;
}
