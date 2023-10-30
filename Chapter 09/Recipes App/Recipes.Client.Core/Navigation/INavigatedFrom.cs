namespace Recipes.Client.Core.Navigation;

//public interface INavigatingFrom
//{
//    Task OnNavigatingFrom(NavigationType navigationType);
//}

public interface INavigatedFrom
{
    Task OnNavigatedFrom(NavigationType navigationType);
}
