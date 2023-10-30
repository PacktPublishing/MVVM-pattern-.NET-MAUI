using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Localization;
using Recipes.Client.Core.Messages;
using Recipes.Client.Core.Navigation;
using Recipes.Client.Core.Services;
using System.Globalization;

namespace Recipes.Client.Core.ViewModels;

public class SettingsViewModel : ObservableObject, INavigationParameterReceiver
{
    readonly ILocalizationManager _localizationManager;
    readonly ILocalizedResourcesProvider _resources;
    readonly INavigationService _navigationService;
    readonly IDialogService _dialogService;

    private string currentLanguage;

    public string CurrentLanguage
    {
        get => currentLanguage;
        set => SetProperty(ref currentLanguage, value);
    }

    public AsyncRelayCommand SelectLanguageCommand { get; }

    public SettingsViewModel(INavigationService service, IDialogService dialogService,
        ILocalizationManager localizationManager, ILocalizedResourcesProvider resources)
    {
        _dialogService = dialogService;
        _localizationManager = localizationManager;
        _resources = resources;
        _navigationService = service;

        SelectLanguageCommand = new AsyncRelayCommand(ChooseLanguage);

        currentLanguage = CultureInfo.CurrentCulture.Name;
    }

    private Task ChooseLanguage()
    {
        return _navigationService.GoToChooseLanguage(CurrentLanguage);
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
        => _dialogService.AskYesNo(
            _resources["SwitchLanguageDialogTitle"],
            _resources["SwitchLanguageDialogText"],
            _resources["YesDialogButton"],
            _resources["NoDialogButton"]);

    private Task NotifySwitch()
        => _dialogService.Notify(
            _resources["LanguageSwitchedTitle"],
            _resources["LanguageSwitchedText"],
            _resources["OKDialogButton"]);

    private void SwitchLanguage(string newLanguage)
    {
        CurrentLanguage = newLanguage;

        var newCulture = new CultureInfo(newLanguage);

        _localizationManager
            .UpdateUserCulture(newCulture);

        WeakReferenceMessenger.Default.Send(
            new CultureChangedMessage(newCulture));
    }

    public Task OnNavigatedTo(Dictionary<string, object> parameters)
    {
        if (parameters is not null && parameters.ContainsKey("SelectedLanguage"))
        {
            return LanguageUpdated(parameters["SelectedLanguage"] as string);
        }
        return Task.CompletedTask;
    }
}
