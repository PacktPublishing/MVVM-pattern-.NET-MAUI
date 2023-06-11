using CommunityToolkit.Mvvm.ComponentModel;

namespace Recipes.Client.Core.ViewModels;

public class RecipeIngredientViewModel : ObservableObject
{
    public IngredientViewModel Ingredient { get; }

    public double BaseAmount { get; }

    double? _displayAmount;
    public double DisplayAmount
    {
        get => _displayAmount ?? BaseAmount;
        set => SetProperty(ref _displayAmount, value);
    }

    public int BaseServings { get; }

    public string? Measurement { get; }

    public RecipeIngredientViewModel(IngredientViewModel ingredient, 
        double baseAmount, string? measurement = null, int baseServings = 4)
    {
        Ingredient = ingredient;
        BaseAmount = baseAmount;
        BaseServings = baseServings;
        Measurement = measurement;
    }

    public void UpdateServings(int servings)
    {
        var factor = servings / (double)BaseServings;
        DisplayAmount = factor * BaseAmount;
    }
}