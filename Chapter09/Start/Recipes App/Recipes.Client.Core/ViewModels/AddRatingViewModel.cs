using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Client.Core.Features.Recipes;
using Recipes.Client.Core.Navigation;

namespace Recipes.Client.Core.ViewModels;

public class AddRatingViewModel : ObservableObject, INavigationParameterReceiver, INavigatedFrom
{

    readonly INavigationService navigationService;

    string _recipeTitle = string.Empty;
    public string RecipeTitle
    {
        get => _recipeTitle;
        private set => SetProperty(ref _recipeTitle, value);
    }

    string _emailAddress;
    public string EmailAddress
    {
        get => _emailAddress;
        set
        {
            SetProperty(ref _emailAddress, value);
        }
    }

    string _displayName;
    public string DisplayName
    {
        get => _displayName;
        set => SetProperty(ref _displayName, value);
    }

    string _ratingInput;
    public string RatingInput
    {
        get => _ratingInput;
        set
        {
            SetProperty(ref _ratingInput, value);
        }
    }

    string _review;
    public string Review
    {
        get => _review;
        set => SetProperty(ref _review, value);
    }

    public RelayCommand GoBackCommand { get; }

    public AsyncRelayCommand SubmitCommand { get; }

    public AddRatingViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        GoBackCommand = new RelayCommand(() => this.navigationService.GoBack());
        SubmitCommand = new AsyncRelayCommand(OnSubmit);
        ResetInputFields();
    }

    private void ResetInputFields()
    {
        EmailAddress = "";
        DisplayName = "";
        RatingInput = "";
        Review = "";
    }

    private async Task OnSubmit()
    {

    }

    private async Task LoadData(RecipeDetailDto recipe)
    {
        RecipeTitle = recipe.Name;
    }

    public Task OnNavigatedTo(Dictionary<string, object> parameters)
    => LoadData(parameters["recipe"]
        as RecipeDetailDto);

    public Task OnNavigatedFrom(NavigationType navigationType)
    {
        if (navigationType == NavigationType.Back)
        {
            ResetInputFields();
        }
        return Task.CompletedTask;
    }
}