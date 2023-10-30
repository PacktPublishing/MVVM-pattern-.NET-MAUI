using Recipes.Mobile.Navigation;

namespace Recipes.Mobile;

public partial class App : Application
{
    public App()
    {
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();

        //Using Shell
        MainPage = new AppShell(ServiceProvider
            .GetService<INavigationInterceptor>());
        //Using Shell

        //Not using Shell
        //MainPage = 
        //ServiceProvider.Current.GetService<INavigationService>().GoToOverview();
        //Not using Shell
    }
}
public class Label
{
    public string Text { get; set; }
}