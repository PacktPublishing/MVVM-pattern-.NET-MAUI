using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Recipes.Client.Core.ViewModels;

public class RecipeRatingsDetailViewModel : ObservableObject
{
    public string RecipeTitle { get; } = "Classic Caesar Salad";

    List<UserReviewViewModel> _reviews = new();
    public List<UserReviewViewModel> Reviews
    {
        get => _reviews;
        private set => SetProperty(ref _reviews, value);
    }

    //ToDo: add Grouped Reviews

    //ToDo: add Selected Reviews

    //ToDO: add ReportReviewCommand

    public RecipeRatingsDetailViewModel()
    {
        Reviews = new()
        {
            new ("Anthony Patrick Newman", 4d),
            new ("Laura Madison", 2.5d, "Very basic recipe, I prefer it with some chicken"),
            new ("Nathan Blake", 4d),
            new ("Kathleen Nicole", 3d, "Tasty salad!"),
            new ("Bradley Stewart", 1d, "I hate it, sorry."),
            new ("Geraldine Naomi Briggs", 2d),
        };

        //ToDo: init GroupedReviews

        //ToDo: init ReportReviewCommand

        //ToDo: subscribe to SelectedReviews.CollectionChanged
    }

    private void ReportReviews()
    {
        //Dummy ReportReviews implementation
        //var selectedReviews = SelectedReviews
        //    .Cast<UserReviewViewModel>().ToList();
        ////do reporting
        //SelectedReviews.Clear();
    }
}
