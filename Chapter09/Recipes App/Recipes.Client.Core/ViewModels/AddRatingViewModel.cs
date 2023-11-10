using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Client.Core.Navigation;
using Recipes.Client.Core.Recipes;
using Recipes.Client.Core.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Recipes.Client.Core.ViewModels;

public class AddRatingViewModel : ObservableValidator, INavigationParameterReceiver, INavigatedFrom
{

    readonly INavigationService _navigationService;
    readonly IDialogService _dialogService;
    public const string EmailValidationRegex = @"^[aA-zZ0-9]+@[aA-zZ]+\.[aA-zZ]{2,3}$";
    public const string RangeDecimalRegex = @"^\d+(\.\d{1,1})?$";
    public const int DisplayNameMinLength = 5;
    public const int DisplayNameMaxLength = 25;
    public const double RatingMinVal = 0d;
    public const double RatingMaxVal = 4d;

    string _recipeTitle = string.Empty;
    public string RecipeTitle
    {
        get => _recipeTitle;
        private set => SetProperty(ref _recipeTitle, value);
    }

    string _emailAddress;
    [Required]
    [RegularExpression(EmailValidationRegex)]
    public string EmailAddress
    {
        get => _emailAddress;
        set
        {
            SetProperty(ref _emailAddress, value, true);
            OnPropertyChanged(nameof(EmailValidationErrors));
        }
    }

    public List<ValidationResult> EmailValidationErrors 
    { 
        get => GetErrors(nameof(EmailAddress)).ToList();
    }
         

    string _displayName;

    [Required]
    [MinLength(DisplayNameMinLength)]
    [MaxLength(DisplayNameMaxLength)]
    public string DisplayName
    {
        get => _displayName;
        set => SetProperty(ref _displayName, value, true);
    }

    string _ratingInput;

    [Required]
    [RegularExpression(RangeDecimalRegex)]
    [Range(RatingMinVal, RatingMaxVal)]
    public string RatingInput
    {
        get => _ratingInput;
        set
        {
            SetProperty(ref _ratingInput, value, true);
            ValidateProperty(Review, nameof(Review));
        }
    }

    string _review;
    

    [CustomValidation(
        typeof(AddRatingViewModel), 
        nameof(ValidateReview))]
    [EmptyOrWithinRange(
        MinLength = 10, MaxLength = 250)]
    public string Review
    {
        get => _review;
        set => SetProperty(ref _review, value, true);
    }
    
    public ValidationErrorExposer ErrorExposer { get; }


    public RelayCommand GoBackCommand { get; }

    public AsyncRelayCommand SubmitCommand { get; }

    public AddRatingViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        GoBackCommand = new RelayCommand(() => _navigationService.GoBack());
        SubmitCommand = new AsyncRelayCommand(OnSubmit, () => !HasErrors);
        Errors = new ();
        ErrorExposer = new (this);
        ErrorsChanged += AddRatingViewModel_ErrorsChanged;
        ResetInputFields();
    }

    private void AddRatingViewModel_ErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
    {
        Errors.Clear();
        GetErrors().ToList().ForEach(Errors.Add);
        Errors.ToList().ForEach(e => Console.WriteLine(e.ErrorMessage));
        SubmitCommand.NotifyCanExecuteChanged();
    }

    private void ResetInputFields()
    {
        EmailAddress = "";
        DisplayName = "";
        RatingInput = "";
        Review = "";
    }

    public ObservableCollection<ValidationResult> Errors { get; } = new();

    private async Task OnSubmit()
    {
        ValidateProperty(EmailAddress, nameof(EmailAddress));
        ValidateProperty(DisplayName, nameof(DisplayName));
        ValidateProperty(DisplayName, nameof(DisplayName));

        if(HasErrors)
        {
            var errors = GetErrors();
            Debug.WriteLine(
                string.Join("\r\n",
                errors.Select(e => e.ErrorMessage)));
        }
        else
        {
            Debug.WriteLine("All OK");
        }
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
            ErrorsChanged -= AddRatingViewModel_ErrorsChanged;
            ErrorExposer.Dispose();
            ResetInputFields();
        }
        return Task.CompletedTask;
    }

    public static ValidationResult ValidateReview(string review, ValidationContext context)
    {
        AddRatingViewModel instance = (AddRatingViewModel)context.ObjectInstance;

        if (double.TryParse(instance.RatingInput, out var rating))
        {
            if (rating <= 2 && string.IsNullOrEmpty(review))
            {
                return new("A review is mandatory when rating the recipe 2 or less.");
            }
        }

        return ValidationResult.Success;
    }
}