using CommunityToolkit.Mvvm.ComponentModel;
using Recipes.Client.Core.Navigation;

namespace Recipes.Client.Core.ViewModels;

public class PickLanguageViewModel : ObservableObject,
    INavigationParameterReceiver
{
    readonly INavigationService _navigationService;

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
        "en-US",
        "fr-FR"
    };

    public PickLanguageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    private Task LanguagePicked()
    {
        return _navigationService.GoBackAndReturn(
            new Dictionary<string, object> {
                { "SelectedLanguage", SelectedLanguage }
            });
    }

    public async Task OnNavigatedTo(Dictionary<string, object> parameters)
    {
        _selectedLanguage = parameters["language"] as string;
        OnPropertyChanged(nameof(SelectedLanguage));
    }
}

