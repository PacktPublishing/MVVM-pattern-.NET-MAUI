using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Client.Core.Features.Ratings;
using Recipes.Client.Core.Features.Recipes;
using Recipes.Client.Core.Navigation;
using Recipes.Client.Core.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Recipes.Client.Core.ViewModels;

public class RecipeRatingsDetailViewModel : ObservableObject, INavigationParameterReceiver, INavigatedTo, INavigatedFrom//, IOnNavigatingFromAware, IOnNavigatingToAware, IOnNavigatedToAware
{
    private readonly IRatingsService ratingsService;
    private readonly INavigationService navigationService;
    private readonly IDialogService dialogService;

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
    public RelayCommand GoBackCommand { get; }

    public RecipeRatingsDetailViewModel(
        INavigationService navigationService,
        IRatingsService ratingsService,
        IDialogService dialogService)
    {
        this.ratingsService = ratingsService;
        this.dialogService = dialogService;
        this.navigationService = navigationService;

        ReportReviewsCommand = new RelayCommand(ReportReviews, () => SelectedReviews.Any());
        GoBackCommand = new RelayCommand(() => navigationService.GoBack());

        SelectedReviews.CollectionChanged += SelectedReviews_CollectionChanged;
    }

    private async Task LoadData(RecipeDetail recipe)
    {
        RecipeTitle = recipe.Name;

        var loadRatings = await ratingsService.LoadRatings(recipe.Id);

        if (loadRatings is { IsSuccess: true, Data: var ratings })
        {
            GroupedReviews = ratings
            .Select(r => new UserReviewViewModel(r.UserName, r.Score, r.Review))
            .GroupBy(r => Math.Round(r.Rating / .5) * .5)
            .OrderByDescending(g => g.Key)
            .Select(g => new RatingGroup(g.Key.ToString(), g.ToList()))
            .ToList();
        }
        else
        {
            var shouldRetry = await dialogService.AskYesNo("Failed to load", "Retry?");
            if (shouldRetry)
                await LoadData(recipe);
            else
                await navigationService.GoBack();
        }
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

    public Task OnNavigatedTo(Dictionary<string, object> parameters)
        => LoadData(parameters["recipe"]
            as RecipeDetail);

    public Task OnNavigatedFrom(NavigationType navigationType)
    {
        return Task.CompletedTask;
    }

    public Task OnNavigatedTo(NavigationType navigationType)
    {
        return Task.CompletedTask;
    }
}
