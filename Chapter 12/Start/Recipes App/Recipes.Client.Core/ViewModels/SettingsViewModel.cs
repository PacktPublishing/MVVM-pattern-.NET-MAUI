using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Client.Core.Navigation;
using System.Globalization;

namespace Recipes.Client.Core.ViewModels;

public class SettingsViewModel : ObservableObject, INavigationParameterReceiver
{
    INavigationService _navigationService;

    private string currentLanguage;

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

        currentLanguage = CultureInfo.CurrentCulture.Name;
    }

    private async Task ChooseLanguage()
    {
        await _navigationService.GoToChooseLanguage(CurrentLanguage);
    }

    private async Task LanguageUpdated(string newLanguage)
    {
        var confirm = await ConfirmSwitchLanguage();

        if (confirm)
        {
            SwitchLanguage(newLanguage);
            await NotifySwitch();
        }
    }

    private Task<bool> ConfirmSwitchLanguage()
    {
        return Task.FromResult(false);
    }

    private Task NotifySwitch()
        => Task.CompletedTask;

    private void SwitchLanguage(string newLanguage)
    {

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
