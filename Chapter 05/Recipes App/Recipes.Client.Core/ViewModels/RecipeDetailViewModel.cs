using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Recipes.Client.Core.ViewModels;

public partial class RecipeDetailViewModel : ObservableObject
{
    public string Title { get; set; } = "Classic Caesar Salad";

    public RecipeRatingsSummaryViewModel RatingSummary { get; set; }
        = new();

    public string[] Allergens { get; }
        = new string[] { "Milk", "Eggs", "Nuts", "Sesame" };

    //Generated property by using the ObservableProperty attribute
    //Remove the full HideExtendedAllergenList property prior to
    //using this attribute
    [ObservableProperty]
    private bool _hideAllergenInformation = true;

    //An implementation of the HideAllergenInformation property 
    //using the SetProperty method.
    //public bool HideAllergenInformation
    //{
    //    get => _hideAllergenInformation;
    //    set => SetProperty(ref _hideAllergenInformation, value);
    //}

    public int? Calories { get; set; } = 240;
    public int? ReadyInMinutes { get; set; } = 30;

    public DateTime LastUpdated { get; set; }
        = new DateTime(2020, 7, 3);

    public string Author { get; set; } = "Sally Burton";
    public string Image { get; set; } = "caesarsalad.png";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddAsFavoriteCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveAsFavoriteCommand))]
    [NotifyCanExecuteChangedFor(nameof(SetFavoriteCommand))]
    private bool _isFavorite = false;
    //public bool IsFavorite
    //{
    //    get => _isFavorite;
    //    private set
    //    {
    //        if (SetProperty(ref _isFavorite, value))
    //        {
    //            AddAsFavoriteCommand.NotifyCanExecuteChanged();
    //            RemoveAsFavoriteCommand.NotifyCanExecuteChanged();
    //            SetFavoriteCommand.NotifyCanExecuteChanged();
    //        }
    //    }
    //}

    public IngredientsListViewModel IngredientsList
    { get; set; } = new();

    //public IRelayCommand AddAsFavoriteCommand
    //{
    //    get;
    //}

    //public IRelayCommand RemoveAsFavoriteCommand
    //{
    //    get;
    //}

    //public IRelayCommand SetFavoriteCommand
    //{
    //    get;
    //}

    public RecipeDetailViewModel()
    {
        //AddAsFavoriteCommand =
        //    new RelayCommand(AddAsFavorite, CanAddAsFavorite);
        //RemoveAsFavoriteCommand =
        //    new RelayCommand(RemoveAsFavorite, CanRemoveAsFavorite);
        //SetFavoriteCommand =
        //       new RelayCommand<bool>(SetFavorite, CanSetFavorite);
    }

    private bool CanSetFavorite(bool isFavorite)
        => IsFavorite != isFavorite;

    [RelayCommand(CanExecute = nameof(CanSetFavorite))]
    private void SetFavorite(bool isFavorite)
        => IsFavorite = isFavorite;

    [RelayCommand(CanExecute = nameof(CanAddAsFavorite))]
    private void AddAsFavorite() => IsFavorite = true;

    [RelayCommand(CanExecute = nameof(CanRemoveAsFavorite))]
    private void RemoveAsFavorite() => IsFavorite = false;

    [RelayCommand]
    private void UserIsBrowsing()
    { 
        //Do Logging
    }

    private bool CanAddAsFavorite()
        => !IsFavorite;

    private bool CanRemoveAsFavorite()
        => IsFavorite;
}