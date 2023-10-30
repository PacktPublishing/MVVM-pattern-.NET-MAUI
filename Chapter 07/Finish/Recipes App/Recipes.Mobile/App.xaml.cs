namespace Recipes.Mobile;

public partial class App : Application
{
	public App()
	{
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        //*/ RecipeRatingDetailPage()
        MainPage = new AppShell();// new NavigationPage(new RecipesOverviewPage()) { BarTextColor = Colors.White };// new RecipeDetailPage();
	}
}
