using CommunityToolkit.Mvvm.ComponentModel;
using Recipes.Client.Core.Navigation;

namespace Recipes.Client.Core.ViewModels;

public class PickLanguageViewModel : ObservableObject
{
    private string _selectedLanguage;

    public string SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            if (SetProperty(ref _selectedLanguage, value))
            {
                LanguagePicked();
            }
        }
    }

    public List<string> Languages { get; set; } = new List<string>()
    {
        "Dutch",
        "French",
        "English",
        "Italian",
        "Spanish"
    };

    public PickLanguageViewModel()
    {

    }

    private Task LanguagePicked()
    {
        return Task.CompletedTask;
    }
}

