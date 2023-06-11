namespace Recipes.Client.Core.ViewModels;

public class UserReviewViewModel
{
    public double Rating { get; } 
    public string UserName { get; }
    public string? Review { get; }

    public UserReviewViewModel(string username, 
        double rating, string? review = null)
    {
        UserName = username;
        Rating = rating;
        Review = review;
    }
}
