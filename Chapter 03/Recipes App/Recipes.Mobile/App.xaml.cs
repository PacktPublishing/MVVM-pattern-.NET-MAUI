namespace Recipes.Mobile;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new RecipeDetailPage();
	}
}
