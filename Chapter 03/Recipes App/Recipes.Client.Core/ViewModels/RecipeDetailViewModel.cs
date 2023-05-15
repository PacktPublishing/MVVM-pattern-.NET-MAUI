using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Recipes.Client.Core.ViewModels;

public class RecipeDetailViewModel : INotifyPropertyChanged
{
    public string Title { get; set; } = "Classic Caesar Salad";

    private bool _showExtendedAllergenList;
    public bool ShowExtendedAllergenList
    {
        get => _showExtendedAllergenList;
        set
        {
            if (_showExtendedAllergenList != value)
            {
                _showExtendedAllergenList = value;
                OnPropertyChanged();
            }
        }
    }

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


    public AllergenInformationViewModel AllergenInformation
    { get; set; } = new AllergenInformationViewModel();

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