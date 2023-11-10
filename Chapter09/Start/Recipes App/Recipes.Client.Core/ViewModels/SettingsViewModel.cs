using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Client.Core.Navigation;

namespace Recipes.Client.Core.ViewModels;

public class SettingsViewModel : ObservableObject, INavigationParameterReceiver
{
    readonly INavigationService _navigationService;

    private string currentLanguage = "English";

    public string CurrentLanguage
    {
        get => currentLanguage;
        set => SetProperty(ref currentLanguage, value);
    }

    public AsyncRelayCommand SelectLanguageCommand { get; }

    public SettingsViewModel(INavigationService service)
    {
        _navigationService = service;
        SelectLanguageCommand = new AsyncRelayCommand(ChooseLanguage);
    }

    private async Task ChooseLanguage()
    {
        await _navigationService
            .GoToChooseLanguage(CurrentLanguage);
    }

    public Task OnNavigatedTo(Dictionary<string, object> parameters)
    {
        if(parameters is not null && parameters.ContainsKey("SelectedLanguage"))
        {
            CurrentLanguage = parameters["SelectedLanguage"] as string;
        }
        return Task.CompletedTask;
    }
}
