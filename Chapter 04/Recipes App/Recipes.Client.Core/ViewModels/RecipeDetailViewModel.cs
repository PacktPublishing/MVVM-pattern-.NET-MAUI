using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Recipes.Client.Core.ViewModels;

public class RecipeDetailViewModel : INotifyPropertyChanged
{
    public string Title { get; set; } = "Classic Caesar Salad";

    public RecipeRatingsDetailViewModel RatingDetail { get; set; }
        =  new ();

    private bool _hideExtendedAllergenList = true;
    public bool HideExtendedAllergenList
    {
        get => _hideExtendedAllergenList;
        set
        {
            if (_hideExtendedAllergenList != value)
            {
                _hideExtendedAllergenList = value;
                OnPropertyChanged();
            }
        }
    }

    public int? Calories { get; set; } = 240;

    public DateTime LastUpdated { get; set; }
        = new DateTime(2020, 7, 3);

    public string Author { get; set; } = "Sally Burton";

    private bool? _isFavorite = false;
    public bool? IsFavorite
    {
        get => _isFavorite;
        private set
        {

            if (_isFavorite != value)
            {
                _isFavorite = value;
                ((Command)AddAsFavoriteCommand).ChangeCanExecute();
                ((Command)RemoveAsFavoriteCommand).ChangeCanExecute();
            }
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

    public RecipeDetailViewModel()
    {
        AddAsFavoriteCommand = new Command(AddAsFavorite, CanAddAsFavorite);
        RemoveAsFavoriteCommand = new Command(RemoveAsFavorite, CanRemoveAsFavorite);
    }

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