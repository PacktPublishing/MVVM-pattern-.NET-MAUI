using Recipes.Client.Core.Navigation;

namespace Recipes.Mobile.Navigation;

public interface INavigationInterceptor
{
    //Task OnNavigatingFrom(object bindingContext, NavigationType navigationType);

    Task OnNavigatedTo(object bindingContext, NavigationType navigationType);

    //Task<bool> CanNavigate(object bindingContext, NavigationType type);

    //Task OnNavigatingTo(IDictionary<string, object> parameters);
}
