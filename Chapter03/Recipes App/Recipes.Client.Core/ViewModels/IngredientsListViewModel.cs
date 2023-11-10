using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Recipes.Client.Core.ViewModels;

public class IngredientsListViewModel : INotifyPropertyChanged
{
    private int _numberOfServings = 4;
    public int NumberOfServings
    {
        get => _numberOfServings;
        set
        {
            if (_numberOfServings != value)
            {
                _numberOfServings = value;
                OnPropertyChanged();
            }
        }
    }

    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler? PropertyChanged;

    //ToDo: add list of Ingredients
}