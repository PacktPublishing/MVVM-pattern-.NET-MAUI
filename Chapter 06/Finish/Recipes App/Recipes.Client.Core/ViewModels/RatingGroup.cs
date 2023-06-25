namespace Recipes.Client.Core.ViewModels;

public class RatingGroup : List<UserReviewViewModel>
{
    public string Key { get; private set; }

    public RatingGroup(string key, 
        List<UserReviewViewModel> reviews) : base(reviews)
    {
        Key = key;
    }
}
