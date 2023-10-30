using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Client.Core.Features.Ratings;
using Recipes.Client.Core.Features.Recipes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Recipes.Client.Core.ViewModels;

public class RecipeRatingsDetailViewModel : ObservableObject
{
    private readonly IRatingsService ratingsService;
    private readonly IRecipeService recipeService;

    string _recipeTitle = string.Empty;
    public string RecipeTitle 
    { 
        get => _recipeTitle;
        set => SetProperty(ref _recipeTitle, value);
    } 

    List<RatingGroup> _groupedReviews = new();
    public List<RatingGroup> GroupedReviews 
    {
        get => _groupedReviews;
        private set => SetProperty(ref _groupedReviews, value);
    }

    public ObservableCollection<object> SelectedReviews { get; } = new();

    public RelayCommand ReportReviewsCommand { get; }

    public RecipeRatingsDetailViewModel(
        IRecipeService recipeService, 
        IRatingsService ratingsService)
    {
        this.recipeService = recipeService;
        this.ratingsService = ratingsService;

        ReportReviewsCommand = new RelayCommand(ReportReviews, () => SelectedReviews.Any());
        SelectedReviews.CollectionChanged += SelectedReviews_CollectionChanged;

        LoadData("3");
    }

    private async Task LoadData(string recipeId)
    {
        var recipeTask = recipeService.LoadRecipe(recipeId);
        var ratingsTask = ratingsService.LoadRatings(recipeId);

        await Task.WhenAll(recipeTask, ratingsTask);

        RecipeTitle = recipeTask.Result?.Name ?? string.Empty;

        GroupedReviews = ratingsTask.Result
            .Select(r => new UserReviewViewModel(r.UserName, r.Rating, r.Review))
            .GroupBy(r => Math.Round(r.Rating / .5) * .5)
            .OrderByDescending(g => g.Key)
            .Select(g => new RatingGroup(g.Key.ToString(), g.ToList()))
            .ToList();
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
