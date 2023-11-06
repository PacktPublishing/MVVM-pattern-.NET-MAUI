namespace Recipes.Client.Core.Navigation;

public interface INavigatedFrom
{
    Task OnNavigatedFrom(NavigationType navigationType);
}
