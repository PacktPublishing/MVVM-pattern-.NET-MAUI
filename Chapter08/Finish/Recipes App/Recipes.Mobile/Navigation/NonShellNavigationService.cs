using Recipes.Client.Core.Features.Recipes;
using Recipes.Client.Core.Navigation;
using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile.Navigation;

public class NonShellNavigationService : INavigationService
{
    protected INavigation Navigation
    {
        get
        {
            INavigation? navigation =
                Application.Current?.MainPage?.Navigation;
            if (navigation is not null)
                return navigation;
            else
            {
                throw new Exception();
            }
        }
    }

    public Task GoBack()
        => Navigation.PopAsync();

    public async Task GoBackAndReturn(Dictionary<string, object> parameters)
    {
        await GoBack();
        if(Navigation.NavigationStack.Last().BindingContext 
            is INavigationParameterReceiver receiver)
            {
                await receiver.OnNavigatedTo(parameters);
            }
    }

    public Task GoToRecipeDetail(string recipeId)
    => Navigate("RecipeDetail",
        new() { { "id", recipeId } });

    public Task GoToRecipeRatingDetail(RecipeDetailDto recipe)
    => Navigate("RecipeRating",
        new() { { "recipe", recipe } });

    public Task GoToOverview()
    => Navigate("Overview", null);

    public Task GoToChooseLanguage(string currentLanguage)
        => Navigate("PickLanguagePage",
        new() { { "language", currentLanguage } });

    private async Task Navigate(string key,
    Dictionary<string, object> parameters)
    {
        var type = Routes.GetType(key);
        var page = ServiceProvider.Current.GetService(type) as Page;

        page.NavigatedFrom += Page_NavigatedFrom;

        await Navigation.PushAsync(page);

        if (page.BindingContext
            is INavigationParameterReceiver receiver)
        {
            await receiver.OnNavigatedTo(parameters);
        }

        if (Navigation.NavigationStack.Count == 1)
        {
            if (page.BindingContext
            is INavigatedTo to)
                await to.OnNavigatedTo(NavigationType.SectionChange);
        }
    }

    private async void Page_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
        //If that entry equals the sender, it means we navigated forward from the sender to another page
        bool isForwardNavigation = Navigation.NavigationStack.Count > 1
            && Navigation.NavigationStack[^2] == sender;
        if (sender is Page page)
        {
            if (!isForwardNavigation)
            {
                page.NavigatedFrom -= Page_NavigatedFrom;
            }
            await OnNavigatedTo(Navigation.NavigationStack.Last().BindingContext,
                isForwardNavigation ? NavigationType.Forward : NavigationType.Back);
        }
    }

    WeakReference<INavigatedFrom> previousFrom;
    private async Task OnNavigatedTo(object bindingContext,
        NavigationType navigationType)
    {
        if (previousFrom is not null && previousFrom
            .TryGetTarget(out INavigatedFrom from))
        {
            await from.OnNavigatedFrom(navigationType);
        }

        if (bindingContext
            is INavigatedTo to)
        {
            await to.OnNavigatedTo(navigationType);
        }

        if (bindingContext is INavigatedFrom navigatedFrom)
            previousFrom = new(navigatedFrom);
        else
            previousFrom = null;
    }
}
