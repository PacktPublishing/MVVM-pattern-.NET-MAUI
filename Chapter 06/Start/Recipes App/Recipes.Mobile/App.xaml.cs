namespace Recipes.Mobile;

public partial class App : Application
{
	public App()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        MainPage = new NavigationPage(new RecipeDetailPage()) { BarTextColor = Colors.White };
	}
}
