namespace Recipes.Client.Core.Navigation;

public interface INavigatable
{
    Task<bool> CanNavigateFrom(NavigationType navigationType);
}
