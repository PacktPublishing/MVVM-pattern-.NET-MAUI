namespace Recipes.Client.Core.Navigation;

public interface INavigationParameterReceiver
{
    Task OnNavigatedTo(Dictionary<string, object> parameters);
}