using Recipes.Client.Core.Navigation;
using Recipes.Mobile.Navigation;

namespace Recipes.Mobile;

public partial class App : Application
{
    //Shell
    public App(INavigationInterceptor interceptor)
    {
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();

        MainPage = new AppShell(interceptor);
    }

    //Not using Shell
    //public App(INavigationService navigationService)
    //{
    //    Application.Current.UserAppTheme = AppTheme.Light;
    //    InitializeComponent();

    //    MainPage = new NavigationPage();

    //    navigationService.GoToOverview();
    //}
}