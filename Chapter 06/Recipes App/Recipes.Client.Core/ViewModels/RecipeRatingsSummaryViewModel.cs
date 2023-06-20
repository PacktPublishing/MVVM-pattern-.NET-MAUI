using CommunityToolkit.Mvvm.ComponentModel;

namespace Recipes.Client.Core.ViewModels;

public class RecipeRatingsSummaryViewModel : ObservableObject
{
    public int TotalReviews { get; } = 15;
    public double MaxRating { get; } = 4d;
    public double? AverageRating { get; } = 3.6d;

    public RecipeRatingsSummaryViewModel(int totalReviews, double? averageRating = null, double maxRating = 4d)
    {
        TotalReviews = totalReviews;
        AverageRating = averageRating;
        MaxRating = maxRating;
    }

    public RecipeRatingsSummaryViewModel()
    {
    
    }
}
