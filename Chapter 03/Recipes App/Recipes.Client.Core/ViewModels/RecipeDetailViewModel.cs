using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Recipes.Client.Core.ViewModels;

public class RecipeDetailViewModel : INotifyPropertyChanged
{
    public string Title { get; set; } = "Classic Caesar Salad";

    private bool _showAllergenInformation;
    public bool ShowAllergenInformation
    {
        get => _showAllergenInformation;
        set
        {
            if (_showAllergenInformation != value)
            {
                _showAllergenInformation = value;
                OnPropertyChanged();
            }
        }
    }

    private bool _isFavorite = false;
    public bool IsFavorite
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
                ((Command<bool>)SetFavoriteCommand).ChangeCanExecute();
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
        => !IsFavorite;
    private bool CanRemoveAsFavorite()
        => IsFavorite;

    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler? PropertyChanged;
}