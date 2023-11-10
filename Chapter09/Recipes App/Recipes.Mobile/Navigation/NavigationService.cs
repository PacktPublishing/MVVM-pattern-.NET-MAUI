using Recipes.Client.Core.Navigation;
using Recipes.Client.Core.Recipes;

namespace Recipes.Mobile.Navigation;

public class NavigationService : INavigationService, INavigationInterceptor
{
    public Task GoToRecipeDetail(string recipeId)
        => Navigate("RecipeDetail", 
            new () { { "id", recipeId } });

    public Task GoToRecipeRatingDetail(RecipeDetailDto recipe)
        => Navigate("RecipeRating",
            new() { { "recipe", recipe } });

    public Task GoToAddRating(RecipeDetailDto recipe)
        => Navigate("AddRating",
           new() { { "recipe", recipe } });

    public Task GoBack()
        =>  Shell.Current.GoToAsync("..");

    private async Task Navigate(string pageName, 
        Dictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(pageName);

        if (Shell.Current.CurrentPage.BindingContext
            is INavigationParameterReceiver receiver)
        {
            await receiver.OnNavigatedTo(parameters);
        }
    }

    WeakReference<INavigatedFrom> previousFrom;
    public async Task OnNavigatedTo(object bindingContext, 
        NavigationType navigationType)
    {
        if(previousFrom is not null && previousFrom
            .TryGetTarget(out INavigatedFrom from))
        {
            await from.OnNavigatedFrom(navigationType);
        }

        if (bindingContext
            is INavigatedTo to)
        {
            await to.OnNavigatedTo(navigationType);
        }

        if(bindingContext is INavigatedFrom navigatedFrom)
            previousFrom = new (navigatedFrom);
        else
            previousFrom = null;
    }

    public Task GoToOverview()
    {
        throw new NotImplementedException();
    }
}


//using Recipes.Client.Core.Navigation;

//namespace Recipes.Mobile.Navigation;

//public class ShellNavigationService : INavigationService
//{
//    public async Task NavigateToRecipeDetailPage(string recipeId)
//    {
//        await Shell.Current.GoToAsync("RecipeDetail");

//        var newPage = Shell.Current.CurrentPage;

//        newPage.NavigatedFrom += Page_NavigatedFrom;
//        newPage.NavigatedTo += Page_NavigatedTo;

//        if (newPage.BindingContext is IOnNavigatingToAware vm && vm != null)
//            await vm.OnNavigatingTo(new Dictionary<string, object>() { { "id", recipeId } });
//    }

//    private async void Page_NavigatedTo(object sender, NavigatedToEventArgs e)
//    {
//        var fromViewModel = (sender as Page).BindingContext as IOnNavigatedToAware;
//        if (fromViewModel is not null)
//            await fromViewModel.OnNavigatedTo();
//    }

//    private async void Page_NavigatedFrom(object sender, NavigatedFromEventArgs e)
//    {
//        //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
//        //If that entry equals the sender, it means we navigated forward from the sender to another page
//        bool isForwardNavigation = Shell.Current.Navigation.NavigationStack.Count > 1
//            && Shell.Current.Navigation.NavigationStack[^2] == sender;

//        if (sender is Page thisPage)
//        {
//            if (!isForwardNavigation)
//            {
//                thisPage.NavigatedTo -= Page_NavigatedTo;
//                thisPage.NavigatedFrom -= Page_NavigatedFrom;
//            }

//            await CallNavigatedFrom(thisPage, isForwardNavigation);
//        }
//    }

//    private Task CallNavigatedFrom(Page p, bool isForward)
//    {
//        var fromViewModel = p.BindingContext as IOnNavigatedFromAware;
//        if (fromViewModel is not null)
//            return fromViewModel.OnNavigatedFrom(isForward);
//        return Task.CompletedTask;
//    }

//    public Task NavigateToRecipeRatingDetailPage(string recipeId)
//    {
//        return Shell.Current.GoToAsync("RecipeRating", new Dictionary<string, object>() { { "id", recipeId } });
//    }
//}
