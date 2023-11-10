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

    List<RatingGroup> _groupedReviews = new();
    public List<RatingGroup> GroupedReviews
    {
        get => _groupedReviews;
        private set => SetProperty(ref _groupedReviews, value);
    }

    public ObservableCollection<object> SelectedReviews { get; } = new();

    public RelayCommand ReportReviewsCommand { get; }

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

        GroupedReviews = Reviews.GroupBy(r => Math.Round(r.Rating / .5) * .5)
            .OrderByDescending(g => g.Key)
            .Select(g => new RatingGroup(g.Key.ToString(), g.ToList()))
            .ToList();

        ReportReviewsCommand = new RelayCommand(ReportReviews, () => SelectedReviews.Any());
        SelectedReviews.CollectionChanged += SelectedReviews_CollectionChanged;
    }

    private void SelectedReviews_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    => ReportReviewsCommand.NotifyCanExecuteChanged();

    private void ReportReviews()
    {
        var selectedReviews = SelectedReviews
            .Cast<UserReviewViewModel>().ToList();
        //do reporting
        SelectedReviews.Clear();
    }
}