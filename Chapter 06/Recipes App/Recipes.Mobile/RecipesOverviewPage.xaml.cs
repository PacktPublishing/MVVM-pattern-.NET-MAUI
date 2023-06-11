using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class RecipesOverviewPage : ContentPage
{
	public RecipesOverviewPage()
	{
		InitializeComponent();
		BindingContext = new RecipesOverviewViewModel();
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		this.Navigation.PushAsync(new RecipeDetailPage());
    }
}