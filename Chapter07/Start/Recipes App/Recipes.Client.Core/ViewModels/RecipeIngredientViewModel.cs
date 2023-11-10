using CommunityToolkit.Mvvm.ComponentModel;

namespace Recipes.Client.Core.ViewModels;

public class RecipeIngredientViewModel : ObservableObject
{
    readonly int baseServings;
    readonly double baseAmount;

    public string IngredientName { get; }

    public string? Measurement { get; }

    double? _displayAmount;
    public double DisplayAmount
    {
        get => _displayAmount ?? baseAmount;
        set => SetProperty(ref _displayAmount, value);
    }


    public RecipeIngredientViewModel(string ingredientName,
        double baseAmount, string? measurement = null, int baseServings = 4)
    {
        IngredientName = ingredientName;
        Measurement = measurement;
        this.baseAmount = baseAmount;
        this.baseServings = baseServings;
    }

    public void UpdateServings(int servings)
    {
        var factor = servings / (double)baseServings;
        DisplayAmount = factor * baseAmount;
    }
}