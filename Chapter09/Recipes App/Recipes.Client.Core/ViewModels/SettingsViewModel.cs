using Recipes.Client.Core.Navigation;

namespace Recipes.Client.Core.ViewModels;

public class SettingsViewModel : INavigatedTo, INavigatedFrom
{
    public Task OnNavigatedFrom(NavigationType navigationType)
    {
        return Task.CompletedTask;
    }

    public Task OnNavigatedTo(NavigationType navigationType)
    {
        return Task.CompletedTask;
    }
}
