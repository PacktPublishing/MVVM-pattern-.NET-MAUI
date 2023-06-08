using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Recipes.Client.Core.ViewModels;

public class RecipeDetailViewModel : INotifyPropertyChanged
{
    public string Title { get; set; } = "Classic Caesar Salad";

    public RecipeRatingsDetailViewModel RatingDetail { get; set; }
        =  new ();

    private bool _hideAllergenInformation = true;
    public bool HideAllergenInformation
    {
        get => _hideAllergenInformation;
        set
        {
            if (_hideAllergenInformation != value)
            {
                _hideAllergenInformation = value;
                OnPropertyChanged();
            }
        }
    }

    public int? Calories { get; set; } = 240;
    public int? ReadyInMinutes { get; set; } = 30;

    public DateTime LastUpdated { get; set; }
        = new DateTime(2020, 7, 3);

    public string Author { get; set; } = "Sally Burton";
    public string Image { get; set; } = "caesarsalad.png";

    private bool? _isFavorite = false;
    public bool? IsFavorite
    {
        get => _isFavorite;
        private set
        {

            if (_isFavorite != value)
            {
                _isFavorite = value;
                OnPropertyChanged();

                ((Command)AddAsFavoriteCommand).ChangeCanExecute();
                ((Command)RemoveAsFavoriteCommand).ChangeCanExecute();
;            }
        }
    }

    public IngredientsListViewModel IngredientsList
    { get; set; } = new();

    public ICommand AddAsFavoriteCommand
    {
        get;
    }

    public ICommand RemoveAsFavoriteCommand
    {
        get;
    }

    public ICommand SetFavoriteCommand
    {
        get;
    }

    public RecipeDetailViewModel()
    {
        AddAsFavoriteCommand = new Command(AddAsFavorite, CanAddAsFavorite);
        RemoveAsFavoriteCommand = new Command(RemoveAsFavorite, CanRemoveAsFavorite);
        
        SetFavoriteCommand =
               new Command<bool>(SetFavorite, CanSetFavorite);
    }

    private bool CanSetFavorite(bool isFavorite)
        => IsFavorite != isFavorite;

    private void SetFavorite(bool isFavorite)
        => IsFavorite = isFavorite;

    private void AddAsFavorite() => IsFavorite = true;
    private void RemoveAsFavorite() => IsFavorite = false;

    private bool CanAddAsFavorite()
        => IsFavorite.HasValue && !IsFavorite.Value;
    private bool CanRemoveAsFavorite()
        => IsFavorite.HasValue && IsFavorite.Value;

    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler? PropertyChanged;
}