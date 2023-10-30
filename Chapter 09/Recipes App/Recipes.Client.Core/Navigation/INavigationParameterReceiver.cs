namespace Recipes.Client.Core.Navigation;

public interface INavigationParameterReceiver
{
    Task OnNavigatedTo(Dictionary<string, object> parameters);
}

//public interface IOnNavigatingToAware
//{
//    Task OnNavigatingTo(Dictionary<string, object> parameters);
//}

//public interface IOnNavigatingFromAware
//{
//    Task OnNavigatingFrom(NavigationType navigationType);
//}

//public interface IOnNavigatedToAware
//{
//    Task OnNavigatedTo();
//}

//public interface IValidateBeforeNavigation
//{
//    Task<bool> CanNavigateFrom(bool isForwardNavigation);
//}


