using Localization;
using Recipes.Mobile.Navigation;

namespace Recipes.Mobile;

public partial class App : Application
{
    public App(INavigationInterceptor interceptor,
    ILocalizationManager manager)
    {
        manager.RestorePreviousCulture();

        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();

        MainPage = new AppShell(interceptor);
    }
}