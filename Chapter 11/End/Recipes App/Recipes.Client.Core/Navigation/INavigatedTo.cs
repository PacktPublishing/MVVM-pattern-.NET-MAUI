namespace Recipes.Client.Core.Navigation;

public interface INavigatedTo
{
    Task OnNavigatedTo(NavigationType navigationType);
}
