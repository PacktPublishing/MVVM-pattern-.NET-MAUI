using Recipes.Client.Core.ViewModels;

namespace Recipes.Mobile;

public partial class RecipeRatingsDetailPage : ContentPage
{
	public RecipeRatingsDetailPage()
	{
		InitializeComponent();
		BindingContext = new RecipeRatingsDetailViewModel();
	}
}