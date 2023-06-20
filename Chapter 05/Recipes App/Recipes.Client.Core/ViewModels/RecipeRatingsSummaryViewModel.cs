namespace Recipes.Client.Core.ViewModels;

public class RecipeRatingsSummaryViewModel
{
    public int TotalReviews { get; } = 15;
    public double MaxRating { get; } = 4d;
    public double? AverageRating { get; set; } = 3.6d;
}
