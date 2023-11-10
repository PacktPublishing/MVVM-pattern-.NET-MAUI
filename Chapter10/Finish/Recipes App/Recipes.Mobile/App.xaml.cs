using Recipes.Mobile.Navigation;

namespace Recipes.Mobile;

public partial class App : Application
{
    public App(INavigationInterceptor interceptor)
    {
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();

        MainPage = new AppShell(interceptor);
    }
}