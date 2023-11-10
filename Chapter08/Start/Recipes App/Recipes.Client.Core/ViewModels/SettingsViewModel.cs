using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Recipes.Client.Core.ViewModels;

public class SettingsViewModel : ObservableObject
{

    private string currentLanguage = "English";

    public string CurrentLanguage
    {
        get => currentLanguage;
        set => SetProperty(ref currentLanguage, value);
    }

    public AsyncRelayCommand SelectLanguageCommand { get; }

    public SettingsViewModel()
    {
        SelectLanguageCommand = new AsyncRelayCommand(ChooseLanguage);
    }

    private async Task ChooseLanguage()
    {
        
    }
}
