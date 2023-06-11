namespace Recipes.Client.Core.ViewModels;

public class RecipeRatingsDetailViewModel
{
    public int TotalReviews { get; } = 15;
    public double MaxRating { get; } = 4d;
    public double? AverageRating { get; } = 3.6d;

    public List<UserReviewViewModel> Reviews
    {
        get;
    }

    public RecipeRatingsDetailViewModel()
    {
        Reviews = new()
        {
            new ("Anthony Paul Newman", 4d),
            new ("Laura Madison", 2.5d, "Very basic recipe, I prefer it with some chicken"),
            new ("Nathan Blake", 4d),
            new ("Kathleen Nicole", 3d, "Tasty salad!"),
            new ("Bradley Stewart", 1d, "I hate it, sorry."),
            new ("Geraldine Naomi Briggs", 2d)
        };
    }
}
